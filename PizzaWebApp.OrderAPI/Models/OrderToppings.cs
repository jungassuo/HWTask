using System.ComponentModel.DataAnnotations;

namespace PizzaWebApp.OrderAPI.Models
{
    public class OrderToppings
    {
        [Key]
        public int ToppingsId { get; set; }
        public string ToppingName { get; set; }
        public int OrderDetailId { get; set; }
    }
}
