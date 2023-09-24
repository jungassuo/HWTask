using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaWebApp.OrderAPI.Models.Dtos
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int ToppingCount { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public IEnumerable<OrderToppingsDto>? OrderToppings { get; set; } = new List<OrderToppingsDto>();
    }
}
