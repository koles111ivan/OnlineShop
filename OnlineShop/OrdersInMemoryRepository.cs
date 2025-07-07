using System.Collections.Generic;
using System;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop
{
    public interface IOrdersRepository
    {
        void Add(Cart cart);
    }

    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private static List<Cart> orders = new List<Cart>();


        public void Add(Cart cart)
        {
            orders.Add(cart);
        }

    }
}
