using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolunTEENProject.Models;
using VolunTEENProject.ViewModels.Home;

namespace VolunTEENProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<EndUser> _signInManager;
        private readonly UserManager<EndUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<EndUser> signInManager, UserManager<EndUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult CreateRole() { 
            return View(); 
        }



        public IActionResult Index()
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