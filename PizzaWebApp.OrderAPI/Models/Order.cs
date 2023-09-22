using PizzaWebApp.OrderAPI.Models.Dtos;

namespace PizzaWebApp.OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public ToppingDto Toppings { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
