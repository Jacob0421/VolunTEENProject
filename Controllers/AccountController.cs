using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VolunTEENProject.Models;
using VolunTEENProject.ViewModels.Account;

namespace VolunTEENProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<EndUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<EndUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateEndUser()
        {
            var roleNames = new List<SelectListItem>();

            roleNames.Add(new SelectListItem
            {
                Text = "Select a User Role",
                Value = "",
                Disabled = true,
                Selected = true
            });

            foreach (var role in _roleManager.Roles)
            {
                roleNames.Add(
                        new SelectListItem
                        {
                            Text = role.Name,
                            Value = role.Name
                        }
                    );
            }

            ViewBag.RoleNames = roleNames;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEndUser(CreateEndUser CreatedUser)
        {
            if (ModelState.IsValid)
            {
                var newUser = new EndUser
                {
                    FirstName = CreatedUser.FirstName,
                    LastName = CreatedUser.lastName,
                    Age = CreatedUser.Age,
                    StreetAddress = CreatedUser.StreetAddress,
                    City = CreatedUser.City,
                    State = CreatedUser.State,
                    ZipCode = CreatedUser.ZipCode,
                    Email = CreatedUser.Email,
                    PhoneNumber = CreatedUser.PhoneNumber,
                    UserName = CreatedUser.UserName,
                    EMailOptIn = CreatedUser.EmailOptIn,
                    TextOptIn = CreatedUser.TextOptIn,
                };

                var result = await _userManager.CreateAsync(newUser, CreatedUser.Password);

                if (result.Succeeded)
                {
                    if(CreatedUser.UserRole != null)
                    {
                        await _userManager.AddToRoleAsync(newUser, CreatedUser.UserRole);
                    } else
                    {
                        await _userManager.AddToRoleAsync(newUser, "User");
                    }
                    return RedirectToAction("Index", "Home");
                } else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            var roleNames = new List<SelectListItem>();

            foreach (var role in _roleManager.Roles)
            {
                roleNames.Add(
                        new SelectListItem
                        {
                            Text = role.Name,
                            Value = role.Name
                        }
                    );
            }

            ViewBag.RoleNames = roleNames;

            return View(CreatedUser);
        }

        public async Task<IActionResult> EndUserDetails(string EndUserID)
        {
            var foundUser = await _userManager.FindByIdAsync(EndUserID);

            if(foundUser != null)
            {
                var model = new EndUserDetails()
                {
                    Id = foundUser.Id,
                    FirstName = foundUser.FirstName,
                    lastName = foundUser.LastName,
                    UserName = foundUser.UserName,
                    Age = foundUser.Age,
                    StreetAddress = foundUser.StreetAddress,
                    City = foundUser.City,
                    State = foundUser.State,
                    ZipCode = foundUser.ZipCode,
                    Email = foundUser.Email,
                    PhoneNumber = foundUser.PhoneNumber,
                    EmailOptIn = foundUser.EMailOptIn,
                    TextOptIn = foundUser.TextOptIn,
                };

                return View(model);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
