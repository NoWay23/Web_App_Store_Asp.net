using System.Drawing;

namespace Web_App_Store.Data.Models
{
    public class ShopGameItem
    {
        public int id {  get; set; }
        public Game game { get; set; }
        public decimal price { get; set; }
        public string ShopGameId { get; set; }
    }
}
