﻿using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;

        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }


        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GameId = item.game.Id,
                    orderId = order.id,
                    price = item.game.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
