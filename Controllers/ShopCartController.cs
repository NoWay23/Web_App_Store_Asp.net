using Microsoft.AspNetCore.Mvc;
using Web_App_Store.Data.Interfaces;
using Web_App_Store.Data.Models;
using Web_App_Store.Data.Repository;
using Web_App_Store.ViewModels;

namespace Web_App_Store.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllGames _gameRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllGames gameRep, ShopCart shopCart)
        {
            _gameRep = gameRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() // позволяет вызвать html шаблон и отобразить корзину
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _gameRep.Games.FirstOrDefault(i => i.Id == id);

            if (item != null) 
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
