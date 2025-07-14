using System.Collections.Generic;
using System;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }

    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private  List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetById(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if (order !=null)
            {
                order.Status = newStatus;
            }
        }
    }
}
