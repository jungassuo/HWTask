using AutoMapper;
using PizzaWebApp.ProductAPI.Models;
using PizzaWebApp.ProductAPI.Models.Dtos;

namespace PizzaWebApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mapping;
        }
    }
}
