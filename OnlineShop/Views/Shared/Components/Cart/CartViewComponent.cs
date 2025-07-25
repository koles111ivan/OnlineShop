﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Helpers;
using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent: ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }      
    }   
}
