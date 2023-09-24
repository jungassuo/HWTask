namespace PizzaWebApp.OrderAPI.Models.Dtos
{
    public class OrderToppingsDto
    {
        public int ToppingsId { get; set; }
        public string ToppingName { get; set; }
        public int OrderDetailId { get; set; }
    }
}
