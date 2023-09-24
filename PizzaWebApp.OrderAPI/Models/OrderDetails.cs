using PizzaWebApp.OrderAPI.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWebApp.OrderAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int ToppingCount { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
