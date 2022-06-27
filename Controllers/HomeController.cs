
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
﻿using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using VolunTEENProject.Models;
using VolunTEENProject.ViewModels.Home;

namespace VolunTEENProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<EndUser> _signInManager;
        private readonly UserManager<EndUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<EndUser> signInManager, UserManager<EndUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if(ViewBag.IsSuccessful != null)
            {
                ViewBag.IsSuccessful = ViewBag.IsSuccessful.ToString();
            }
            return View();
        }

        public async Task<IActionResult> UploadFiles(UploadFile model)
        {

            string blobStorageConnection = _configuration.GetConnectionString("BlobConnection");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobStorageConnection);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));

            foreach (var file in model.files)
            {

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("TestUploads/" + file.FileName);
                await using(var data = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(data);
                }

            }

            ViewBag.IsSuccessful = "Successful";
            return View("Index");
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login details)
        {
            if (ModelState.IsValid)
            {
                var foundUser = _userManager.Users.FirstOrDefault(u => u.UserName == details.UserName);

                if (foundUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(foundUser, details.Password, false, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index");
                    } else
                    {
                        return View(details);
                    }
                }
            }
            return View(details);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}