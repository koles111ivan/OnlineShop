using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl});
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl);
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
        public IActionResult Register()
        {
            return View();
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
                usersManager.Add(new UserAccount
                {
                    Name = register.UserName,
                    Password = register.Password,
                    Phone = register.Phone
                });
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(Register));
        }
    }
}
