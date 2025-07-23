using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Helpers;
using System;

namespace OnlineShop.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductsRepository productsRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductsRepository productsRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(Constants.UserId);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            favoriteRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int productId)
        {
            favoriteRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }

    }
}
