using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Db;
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
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath,
                };
                productsViewModel.Add(productViewModel);
            }
            if(!string.IsNullOrEmpty(search))
            {
                productsViewModel = productsViewModel.Where(p=>p.Name.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.Search = search;
            return View(productsViewModel);
        }           
    }
}
