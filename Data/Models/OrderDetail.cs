namespace Web_App_Store.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int GameId { get; set; }
        public decimal price { get; set; }
        public virtual Game game { get; set; }
        public virtual Order order { get; set; }
    }
}
