using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Controllers;
using OnlineShop.Models;
using System;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccounts = usersManager.GetAll();
            return View(userAccounts);
        }

        public IActionResult Detail(int id)
        {
            var userAccount = usersManager.TryGetById(id);
            return View(userAccount);
        }

        public IActionResult ChangePassword(int id)
        {
            var user = usersManager.TryGetById(id);
            if (user == null)
                return NotFound();
            var changePassword = new ChangePassword()
            {
                UserId = user.Id,
                UserName = user.Name
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersManager.ChangePasswordById(changePassword.UserId, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(changePassword);
        }

        public IActionResult Edit(int id)
        {
            var user = usersManager.TryGetById(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(int id, UserAccount user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var existing = usersManager.TryGetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Password = user.Password;
            existing.Name = user.Name;
            existing.Phone = user.Phone;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditRights(int id)
        {
            var user = usersManager.TryGetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult EditRights(int id, string role)
        {
            usersManager.ChangeRole(id, role);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            usersManager.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
