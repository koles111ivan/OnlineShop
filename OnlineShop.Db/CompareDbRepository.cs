using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Linq;

namespace OnlineShop.Db
{
    public class CompareDbRepository : ICompareRepository
    {
        private readonly DataBaseContext dataBaseContext;
        public CompareDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public void Add(string userId, Product product)
        {
            var existingProduct = dataBaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                dataBaseContext.CompareProducts.Add(new CompareProduct { Product = product, UserId = userId });
                dataBaseContext.SaveChanges();
            }
        }
        public void Clear(string userId)
        {
            var userCompareProducts = dataBaseContext.CompareProducts.Where(u => u.UserId == userId).ToList();
            dataBaseContext.CompareProducts.RemoveRange(userCompareProducts);
            dataBaseContext.SaveChanges();
        }
        public List<Product> GetAll(string userId)
        {
            return dataBaseContext.CompareProducts.Where(x => x.UserId == userId)
                                                .Include(x => x.Product)
                                                .Select(x => x.Product)
                                                .ToList();
        }
        public void Remove(string userId, int productId)
        {
            var removingCompare = dataBaseContext.CompareProducts.FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
            dataBaseContext.CompareProducts.Remove(removingCompare);
            dataBaseContext.SaveChanges();
        }
    }
}