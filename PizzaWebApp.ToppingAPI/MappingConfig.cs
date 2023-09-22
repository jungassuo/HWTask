using AutoMapper;
using PizzaWebApp.ToppingAPI.Models;
using PizzaWebApp.ToppingAPI.Models.Dtos;

namespace PizzaWebApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<ToppingDto, Topping>().ReverseMap();
            });
            return mapping;
        }
    }
}
