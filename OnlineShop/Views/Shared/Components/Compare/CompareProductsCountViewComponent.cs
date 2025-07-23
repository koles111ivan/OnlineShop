using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShop.ViewComponents
{
    public class CompareProductsCountViewComponent : ViewComponent
    {
        private readonly ICompareRepository compareRepository;
        public CompareProductsCountViewComponent(ICompareRepository compareRepository)
        {
            this.compareRepository = compareRepository;
        }
        public IViewComponentResult Invoke()
        {
            var productsCount = compareRepository.GetAll(Constants.UserId).Count;
            return View(productsCount);
        }
    }
}