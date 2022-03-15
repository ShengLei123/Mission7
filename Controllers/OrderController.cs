using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Basket basket { get; set; }
        public OrderController(IOrderRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(basket.Items.Count()==0)
            {
                ModelState.AddModelError("", "Basket is empty");
            }
            if (ModelState.IsValid)
            {
                order.Lines = basket.Items.ToArray();
                repo.SaveOrders(order);
                basket.ClearBasket();

                return RedirectToPage("/OrderCompleted");
            }
            else
            {
                return View();
            }
            IdentitySeedData.num = IdentitySeedData.num + 5;
        }
    }
}
