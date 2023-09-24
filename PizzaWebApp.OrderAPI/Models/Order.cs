using PizzaWebApp.OrderAPI.Models.Dtos;

namespace PizzaWebApp.OrderAPI.Models
{
    public class Order
    {
        public OrderHeaderDto OrderHeader { get; set; }
        public IEnumerable<OrderDetailsDto>? OrderDetails { get; set; }
        public IEnumerable<OrderToppingsDto>? OrderToppings { get; set; }
    }
}
