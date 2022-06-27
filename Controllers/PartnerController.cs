using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Globalization;
using VolunTEENProject.Models;
using VolunTEENProject.Models.Repositories;
using VolunTEENProject.ViewModels.Partner;

namespace VolunTEENProject.Controllers
{
    public class PartnerController : Controller
    {

        private readonly IPartnerRepository _partnerRepository;
        private readonly UserManager<EndUser> _userManager;
        private readonly IConfiguration _config;

        public PartnerController(IPartnerRepository partnerRepository, IConfiguration config, UserManager<EndUser> userManager)
        {
            _partnerRepository = partnerRepository;
            _config = config;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(CreatePartner model)
        {

            if (ModelState.IsValid)
            {

                Partner newPartner = new Partner
                {
                    PartnerName = model.PartnerName,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    PhoneNumber = model.PhoneNumber,
                    StreetAddress = model.StreetAddress,
                    AddressSecondLine = model.AddressSecondLine,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    CreatedTime = DateTime.Now
                };
                string uploadLocation = ("PartnerLogos/" + model.PartnerName.Replace(" ", "") + "Logo");

                string blobStorageConnection = _config.GetConnectionString("BlobConnection");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobStorageConnection);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(_config.GetValue<string>("BlobContainerName"));
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadLocation);
                try
                {
                    await using (var data = model.PartnerLogo.OpenReadStream())
                    {
                        await blockBlob.UploadFromStreamAsync(data);
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "File could not be uploaded at this time. Please try again or contact an administrator.");
                    return View(model);
                }
                newPartner.PartnerLogo = uploadLocation;

                _partnerRepository.CreatePartner(newPartner);

                ViewBag.IsSuccessful = "This was successful";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult AddUser()
        {
            
            ViewBag.UserList = CreateUserList();
            ViewBag.PartnerList = CreatePartnerList();

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUser model)
        {

            if (ModelState.IsValid)
            {

                var toBeAdded = _userManager.Users.FirstOrDefault(u => u.Id == model.userID);
                var toBeUpdated = _partnerRepository.GetPartners().FirstOrDefault(p => p.PartnerID == Int32.Parse(model.partnerID));

                _partnerRepository.AddUser(toBeAdded, toBeUpdated);

                return RedirectToAction("Index", "Home");

            }

            ViewBag.UserList = CreateUserList();
            ViewBag.PartnerList = CreatePartnerList();

            return View();
        }

        ///**************************************************************///
        ///*************************Functions****************************///
        ///**************************************************************///

        public List<SelectListItem> CreatePartnerList()
        {

            List<SelectListItem> partnerList = new List<SelectListItem>();

            partnerList.Add(new SelectListItem
            {
                Text = "Select a Partner to be added to",
                Value = "",
                Disabled = true,
                Selected = true
            });

            foreach (var partner in _partnerRepository.GetPartners())
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = partner.PartnerID.ToString(),
                    Text = partner.PartnerName
                };

                partnerList.Add(selectListItem);
            }

            return partnerList;
        }

        public List<SelectListItem> CreateUserList()
        {
            List<SelectListItem> userList = new List<SelectListItem>();

            userList.Add(new SelectListItem
            {
                Text = "Select a User to Add",
                Value = "",
                Disabled = true,
                Selected = true
            });

            foreach (var user in _userManager.Users)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Value = user.Id,
                    Text = (user.FirstName + " " + user.LastName)
                };

                userList.Add(selectListItem);
            }

            return userList;

        }
    }
}
