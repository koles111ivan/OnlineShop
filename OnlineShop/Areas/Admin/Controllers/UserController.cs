using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Helpers;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> usersManager;
        private readonly RoleManager<IdentityRole> rolesManager;

        public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager)
        {
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            var users = usersManager.Users.ToList();
            return View(users.Select(x => x.ToUserViewModel()).ToList());
        }

        public async Task<IActionResult> Detail(string name)
        {
            var user = await usersManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                var user = await usersManager.FindByNameAsync(changePassword.UserName);
                var newHashPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                await usersManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await usersManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = await usersManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = userModel.Name;
            user.PhoneNumber = userModel.Phone;

            var result = await usersManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userModel);
            }

            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> EditRights(string id)
        //{
        //    var user = await usersManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user.ToUserViewModel());
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditRights(string id, string role)
        //{
        //    var user = await usersManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Удаляем все текущие роли
        //    var currentRoles = await usersManager.GetRolesAsync(user);
        //    await usersManager.RemoveFromRolesAsync(user, currentRoles);

        //    // Добавляем новую роль
        //    var result = await usersManager.AddToRoleAsync(user, role);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return View(user.ToUserViewModel());
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        public async Task<IActionResult> Delete(string id)
        {
            var user = await usersManager.FindByIdAsync(id);
            if (user != null)
            {
                await usersManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditRights(string name)
        {
            var user = usersManager.FindByIdAsync(name).Result;
            var userRoles = usersManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name}).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectedRoles = userRolesViewModel.Select(x => x.Key);

            var user = usersManager.FindByIdAsync(name).Result;
            var userRoles = usersManager.GetRolesAsync(user).Result;

            usersManager.RemoveFromRolesAsync(user, userRoles).Wait();
            usersManager.AddToRolesAsync(user, userSelectedRoles).Wait();
            return RedirectToAction("Detail", name);
        }
    }
}