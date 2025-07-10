using OnlineShop.Models;
using System.Linq;
using System.Collections.Generic;

namespace OnlineShop
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Линекс форте", 1099,"Лактобактерии ацидофиллус, Бифидобактерии ВВ12", "/images/линекс форте.png"),
            new Product("Дона", 1671, "Глюкозамин", "/images/Дона.webp"),
            new Product("Фитолакс", 521,"Эвалар", "/images/Фитолакс.webp"),
            new Product("Гептрал", 1939, "Действующим веществом является адеметионин.", "/images/Гептрал.jpg" ),
            new Product("Тантум верде", 860, "От боли в горле", "/images/тантум верде.jpg" ),

        };

        public void Add(Product product)
        {
            product.ImagePath = "/images/линекс форте.png";
            products.Add(product);
        }
        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
        }
    }
}
