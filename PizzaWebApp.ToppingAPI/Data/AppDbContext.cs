using Microsoft.EntityFrameworkCore;
using PizzaWebApp.ToppingAPI.Models;

namespace PizzaWebApp.ToppingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Topping> Topping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 1,
                Name = "Tomatoes",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 2,
                Name = "Broccoli",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 3,
                Name = "Red Pepper",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 4,
                Name = "Pepperoni",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 5,
                Name = "Bacon",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 6,
                Name = "Basil",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 7,
                Name = "Mushroom",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 8,
                Name = "Onion",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                ToppingId = 9,
                Name = "Extra Cheese",
            });
        }
    }
}
