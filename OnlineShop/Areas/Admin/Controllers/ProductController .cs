using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Models;
using System;
using System.Collections.Generic;

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
            return View(productsViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };
            productsRepository.Add(productDb);
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
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };
            productsRepository.Update(productDb);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            productsRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
