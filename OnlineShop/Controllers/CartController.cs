﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }



        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart); 
        }
        public IActionResult Add (int productId)
        {
            var product = productRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");

        }
        public IActionResult DecreaseAmount(int productId)
        {
            cartsRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");

        }
        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
