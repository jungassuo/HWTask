using AutoMapper;
using PizzaWebApp.ToppingAPI.Models;
using PizzaWebApp.ToppingAPI.Models.Dtos;

//Mapping configuration class
//Mapper is used in functions, where api needs to convert data transfer objects (DTOs)
//DTOs are used to transfer application data between the server and the client
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
