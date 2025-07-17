using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop
{
    public interface IProductsRepository
    {
        void Add(Product product);
        void Update(Product product);
        List<Product> GetAll();
        Product TryGetById(int id);
        void Remove(int id);
    }
}