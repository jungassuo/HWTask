using Microsoft.EntityFrameworkCore;
using PizzaWebApp.OrderAPI.Models;

namespace Pizza_Order_Web_App.OrderAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    
    }
}
