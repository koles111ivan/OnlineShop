using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Helpers;
using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop.Views.Shared.Components.Favorite
{
    public class FavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        public FavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }
        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteRepository.GetAll(Constants.UserId).Count;
            return View(productsCount);
        }
    }
}
