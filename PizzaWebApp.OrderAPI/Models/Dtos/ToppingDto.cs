﻿namespace PizzaWebApp.OrderAPI.Models.Dtos
{
    public class ToppingDto
    {
        public int ToppingsId { get; set; }
        public string ToppingName { get; set; }
        public int OrderDetailId { get; set; }
    }
}
