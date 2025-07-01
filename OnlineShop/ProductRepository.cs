using OnlineShop.Models;
using System.Linq;
using System.Collections.Generic;

namespace OnlineShop
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Линекс форте", 1099,"Лактобактерии ацидофиллус, Бифидобактерии ВВ12"),
            new Product("Дона", 1671, "Глюкозамин"),
            new Product("Фитолакс", 521,"Эвалар"),
            new Product("PILULI", 349, "Мармеладные жевательные пастилки Кальций" ),
        };
        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
