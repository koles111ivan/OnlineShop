using System.Collections.Generic;
using System;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }

    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private static List<Order> orders = new List<Order>();


        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetAll()
        {
            return orders;
        }
    }
}
