using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineShop.Db.Models;
using OnlineShop.Models;
using System;
using System.Threading.Tasks;
using OnlineShop.Db;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }
            return View(login);
        }
        //[HttpPost]
        //public IActionResult Login(Login login)
        //{
        //    if (!ModelState.IsValid)
        //        return RedirectToAction(nameof(Login));
        //    var userAccount = usersManager.TryGetByName(login.UserName);
        //    if (userAccount == null)
        //    {
        //        ModelState.AddModelError("", "Такого пользователя не существует");
        //        return RedirectToAction(nameof(Login));
        //    }

        //    if (userAccount.Password != login.Password)
        //    {
        //        ModelState.AddModelError("", "Неправильный пароль");
        //        return RedirectToAction(nameof(Login));
        //    }

        //    return RedirectToAction("Index","Home");                      
        //}

        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User user = new User { Email = register.UserName, UserName = register.UserName, PhoneNumber = register.Phone };
                var result = _userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRole(user);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);

        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, Db.Constants.UserRoleName).Wait();
            }
            catch (Exception)
            {

            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Register(Register register)
        //{
        //    if (register.UserName == register.Password)
        //    {
        //        ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        usersManager.Add(new UserAccount
        //        {
        //            Name = register.UserName,
        //            Password = register.Password,
        //            Phone = register.Phone
        //        });
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return RedirectToAction(nameof(Register));
        //}
    }
}