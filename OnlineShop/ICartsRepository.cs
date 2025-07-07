using OnlineShop.Models;

namespace OnlineShop
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(int productId, string userId);
        Cart TryGetByUserId(string userId);
    }
}