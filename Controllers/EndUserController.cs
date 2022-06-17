using Microsoft.AspNetCore.Mvc;

namespace VolunTEENProject.Controllers
{
    public class EndUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
