﻿namespace PizzaWebApp.ProductAPI.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public SizeEnum Size { get; set; }
    }
}
