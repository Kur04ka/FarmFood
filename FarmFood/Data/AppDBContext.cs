using FarmFood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmFood.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){ 
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ShopCart> ShopCart { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
    }
}
