﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Helpers;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
            }
            var existingCart=cartsRepository.TryGetByUserId(Constants.UserId);
            var existingCartViewModel = Mapping.ToCartViewModel(existingCart);
            var order = new Order
            {
                User = user,
                Items = existingCart.Items,
            };
            ordersRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
