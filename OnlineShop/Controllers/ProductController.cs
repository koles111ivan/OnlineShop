﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productRepository = productsRepository;
        }
        public IActionResult Index (int id)
        {
            var product = productRepository.TryGetById(id);
            return View(product);

        }
    }
}
