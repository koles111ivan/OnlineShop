using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
    }
}