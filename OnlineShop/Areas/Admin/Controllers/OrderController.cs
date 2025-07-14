using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {    
        private readonly IOrdersRepository ordersRepository; 
        public OrderController(IOrdersRepository ordersRepository)
        {      
            this.ordersRepository = ordersRepository;         
        }
        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult Detail(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }       
    }
}
