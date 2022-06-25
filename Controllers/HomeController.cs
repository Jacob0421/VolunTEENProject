using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Diagnostics;
using VolunTEENProject.Models;
using VolunTEENProject.ViewModels.Home;

namespace VolunTEENProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}