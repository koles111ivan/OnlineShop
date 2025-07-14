using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using System;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;      
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;          
        }
  
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
