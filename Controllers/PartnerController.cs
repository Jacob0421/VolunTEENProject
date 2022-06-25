using Microsoft.AspNetCore.Mvc;
using VolunTEENProject.ViewModels.Partner;

namespace VolunTEENProject.Controllers
{
    public class PartnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(CreatePartner newPartner)
        {
            return View();
        }

    }
}
