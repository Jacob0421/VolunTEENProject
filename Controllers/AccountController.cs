using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunTEENProject.ViewModels.Account;

namespace VolunTEENProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult CreateUser(CreateEndUser CreatedUser) {
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
