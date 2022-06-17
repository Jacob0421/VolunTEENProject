using Microsoft.AspNetCore.Mvc;

namespace VolunTEENProject.Controllers
{
    public class OpportunityController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
