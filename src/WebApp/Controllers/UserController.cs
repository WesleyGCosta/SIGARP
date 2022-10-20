using Domain.Entities;
using Domain.Notifications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Management()
        {
            return View(await GetAsyncListUsers());
        }

        private async Task<List<User>> GetAsyncListUsers()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            foreach (var user in users)
            {
                user.Role = new List<string>(await _userManager.GetRolesAsync(user));
            }

            return users;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            await ViewBagRoles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserFactory.ToIdentityUser(model);

                var resultCreate = await _userManager.CreateAsync(user, model.Password);            

                if (resultCreate.Succeeded)
                {
                    var resultAddRole = await _userManager.AddToRoleAsync(user, model.Role);
                    if (resultAddRole.Succeeded)
                        return RedirectToAction(nameof(Management));
                }

                foreach (var error in resultCreate.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            await ViewBagRoles();
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Gerente")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roleUser = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
                TempData["Warning"] = "Usuário não encontrado";
                return NotFound();
            }
            await ViewBagRoles();
            var userViewModel = UserFactory.ToViewModel(user, roleUser.First());
            return PartialView("_FormEditUserModal", userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            var user = UserFactory.ToIdentityUser(userViewModel);
            var userConsult = await _userManager.FindByIdAsync(userViewModel.Id);
            var roleUser = await _userManager.GetRolesAsync(userConsult);

            if (userConsult != null)
            {
                userConsult.Update(user);
                var resultUser = await _userManager.UpdateAsync(userConsult);
                var resultRoles = await _userManager.RemoveFromRolesAsync(userConsult, roleUser);
                await _userManager.AddToRoleAsync(userConsult, userViewModel.Role);

                foreach (var error in resultUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            TempData["Success"] = "Usuário alterado com sucesso";
            return PartialView("_ListUser", await GetAsyncListUsers());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            TempData["Success"] = "Usuário excluído com sucesso";

            return PartialView("_ListUser", await GetAsyncListUsers());
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

        public IActionResult RestrictedAcess()
        {
            return StatusCode(403);
        }

        private async Task ViewBagRoles()
        {
            ViewBag.Roles = new SelectList(await _roleManager.Roles.AsNoTracking().OrderBy(r => r.Name).ToListAsync(), "Name", "Name");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
