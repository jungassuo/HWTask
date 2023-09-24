namespace PizzaWebApp.OrderAPI.Models.Dtos
{
    public class OrderDto
    {
        public OrderHeaderDto OrderHeader { get; set; }
        public List<OrderDetailsDto>? OrderDetails { get; set; } = new List<OrderDetailsDto>();
        public IEnumerable<OrderToppingsDto>? OrderToppings { get; set; } = new List<OrderToppingsDto>();
    }
}
