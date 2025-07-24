using System.Collections.Generic;
using System;
using System.Linq;
using OnlineShop.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public interface IOrdersRepository
    {
        void Add(Order order);        
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }

    public class OrdersDbRepository : IOrdersRepository
    {
        private  readonly DataBaseContext dataBaseContext;
        public OrdersDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(Order order)
        {
            dataBaseContext.Orders.Add(order);
            dataBaseContext.SaveChanges();
        }
        public List<Order> GetAll()
        {
            return dataBaseContext.Orders.Include(x=>x.User)
                   .Include(x=>x.Items).ThenInclude(x=>x.Product).ToList();
        }

        public Order TryGetById(Guid id)
        {
            return dataBaseContext.Orders.Include(x=>x.User)
                  .Include(x=>x.Items)
                  .ThenInclude(x=>x.Product).FirstOrDefault(order => order.Id == id);
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
