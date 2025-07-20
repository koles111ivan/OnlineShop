using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
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