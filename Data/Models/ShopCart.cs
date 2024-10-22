using Microsoft.EntityFrameworkCore;

namespace Web_App_Store.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopGameId { get; set; } // параметр для разбиения корзины

        public List<ShopGameItem> listShopItems { get; set;} // список всех элементов отображенных в корзине

        public ShopCart()
        {
            listShopItems = new List<ShopGameItem>();
        }

        public static ShopCart GetCart(IServiceProvider services) // позволяет понять добовлял ли элементы в корзину
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(contex) { ShopGameId = shopCartId };
        }

        public void AddToCart(Game game) // добавление в корзину
        {
            appDBContent.ShopGameItem.Add(new ShopGameItem
            {
                ShopGameId = ShopGameId,
                game = game,
                price = game.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopGameItem> GetShopItems()  // отображение товаров в корзине
        {
            return appDBContent.ShopGameItem.Where(c => c.ShopGameId == ShopGameId).Include(s => s.game).ToList();
        }
    }
}
