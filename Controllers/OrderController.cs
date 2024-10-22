using Microsoft.AspNetCore.Mvc;
using Web_App_Store.Data;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders allOrders;

        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }


        public IActionResult CheckOut() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopItems();

            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Должны быть товары");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complet");
            }

            return View();
        }

        public IActionResult Complet()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}