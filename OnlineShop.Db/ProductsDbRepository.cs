
using System.Linq;
using System.Collections.Generic;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductsDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        private List<Product> products;
        private int nextId = 1;

        public ProductsDbRepository()
        {
            //products = new List<Product>
            //{
            //    new Product("Линекс форте", 1099,"Лактобактерии ацидофиллус, Бифидобактерии ВВ12", "/images/линекс форте.png"),
            //    new Product("Дона", 1671, "Глюкозамин", "/images/Дона.webp"),
            //    new Product("Фитолакс", 521,"Эвалар", "/images/Фитолакс.webp"),
            //    new Product("Гептрал", 1939, "Действующим веществом является адеметионин.", "/images/Гептрал.jpg" ),
            //    new Product("Тантум верде", 860, "От боли в горле", "/images/тантум верде.jpg" ),
            //    new Product("Зодак", 290, "Таблетки от аллергии", "/images/Зодак.jpg" ),
            //    new Product("Nivea Sun", 1132, "Спрей от солнца", "/images/Nivea_Sun.jpg" ),
            //    new Product("Нурофен", 197, "От боли в голове", "/images/нурофен.webp" ),
            //};
            foreach (var p in products)
            {
                p.Id = nextId++;
            }
        }

        public void Add(Product product)
        {
           
            if (string.IsNullOrEmpty(product.ImagePath))
                product.ImagePath = "/images/линекс форте.png";
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }
        public List<Product> GetAll()
        {
            return dataBaseContext.Products.ToList() ;
        }

        public Product TryGetById(int id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            dataBaseContext.SaveChanges();
        }
        public void Remove(int id)
        {
            var product = dataBaseContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            dataBaseContext.SaveChanges();
        }

        
    }
}
