using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;
        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }
        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        
        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }
    }
}
