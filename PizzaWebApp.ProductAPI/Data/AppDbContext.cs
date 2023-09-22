using Microsoft.EntityFrameworkCore;
using PizzaWebApp.ProductAPI.Models;

namespace PizzaWebApp.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Pepperoni Special",
                Description = "Salami, ham, bacon, mushroom, green pepper.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Vegetarian",
                Description = "Mushroom, onion, green pepper, sweet corn, black olives.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Margarita",
                Description = "Slice tomato.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Hawaiian",
                Description = "Ham, pineapple.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Quattro Stagioni",
                Description = "Ham, mushroom, prawns, artichoke, black olives",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Capricciosa",
                Description = "Ham, mushroom",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Riviera",
                Description = "Prawns, mushroom.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Chicken Pesto",
                Description = "Pesto base sauce, marinated grilled chicken, mozzarella cheese, tomato.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Frutti di Mare",
                Description = "Tuna, anchovies, black olives.",
                ImageUrl = "https://placehold.co/602x402"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Super Crazy",
                Description = "Ham, mushroom, pepperoni, haloumi, green pepper, onion, black olives, tomato, oregano.",
                ImageUrl = "https://placehold.co/602x402"
            });
        }
    }
}
