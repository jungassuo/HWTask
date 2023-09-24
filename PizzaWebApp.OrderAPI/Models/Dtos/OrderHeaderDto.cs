using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWebApp.OrderAPI.Models.Dtos
{
    public class OrderHeaderDto
    {
        public int OrderHeaderId { get; set; }
        public decimal TotalCost { get; set; }
        public int Count { get; set; }
    }
}
