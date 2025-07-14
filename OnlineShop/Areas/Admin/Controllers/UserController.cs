using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using System;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }
    
    }
}
