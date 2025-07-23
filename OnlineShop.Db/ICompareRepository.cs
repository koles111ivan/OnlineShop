using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface ICompareRepository
    {
        void Add(string userId, Product product);
        void Remove(string userId, int productId);
        List<Product> GetAll(string userId);
        void Clear(string userId);
    }
}