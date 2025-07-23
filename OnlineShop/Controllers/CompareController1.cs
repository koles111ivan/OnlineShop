using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Helpers;
using System;

namespace OnlineShop.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareRepository compareRepository;
        private readonly IProductsRepository productsRepository;

        public CompareController(ICompareRepository compareRepository, IProductsRepository productsRepository)
        {
            this.compareRepository = compareRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = compareRepository.GetAll(Constants.UserId);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            compareRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int productId)
        {
            compareRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            compareRepository.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}