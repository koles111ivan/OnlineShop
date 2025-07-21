using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Db;
using OnlineShop.Helpers;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        
        public HomeController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;         
        }

        public IActionResult Index(string search)
        {        
            var products = productRepository.GetAll();            
            if(!string.IsNullOrEmpty(search))
            {
                products = products.Where(p=>p.Name.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.Search = search;
            return View(Mapping.ToProductViewModels(products));
        }           
    }
}
