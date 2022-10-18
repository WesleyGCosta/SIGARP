using Domain.Entities;
using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            INotifier notifier) : base(notifier)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Management()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            foreach(var user in users)
            {
                user.Role = new List<string>(await _userManager.GetRolesAsync(user));
            }
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList(await _roleManager.Roles.AsNoTracking().OrderBy(r => r.Name).ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserFactory.ToIdentityUser(model);

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Login inválido");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logar(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.Lembrar, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");

            }
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
