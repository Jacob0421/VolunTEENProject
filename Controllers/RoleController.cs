using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VolunTEENProject.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Site Admin")]
        public IActionResult CreateRole() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole newRole)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                } 

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(newRole);
        }

    }
}
