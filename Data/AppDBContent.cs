using Microsoft.EntityFrameworkCore;
using Web_App_Store.Data.Models;

namespace Web_App_Store.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options): base(options) 
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopGameItem> ShopGameItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
