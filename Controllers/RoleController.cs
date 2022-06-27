using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunTEENProject.Models;
using VolunTEENProject.ViewModels.Role;

namespace VolunTEENProject.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateRole() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole role)
        {
            if (ModelState.IsValid)
            {

                Role newRole = new Role()
                {
                    Name = role.Name,
                    RoleDescription= role.Description,
                    IsPartnerRole= role.IsPartnerRole,
                };

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
            return View(role);
        }

    }
}
