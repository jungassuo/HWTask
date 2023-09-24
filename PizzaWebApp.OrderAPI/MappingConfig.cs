using AutoMapper;
using PizzaWebApp.OrderAPI.Models;
using PizzaWebApp.OrderAPI.Models.Dtos;

namespace PizzaWebApp.OrderAPI
{
    public class MappingConfig
    {
            public static MapperConfiguration RegisterMaps()
            {
                var mapping = new MapperConfiguration(config =>
                {
                    config.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
                    config.CreateMap<OrderHeaderDto, OrderHeader>().ReverseMap();
                    config.CreateMap<OrderToppingsDto, OrderToppings>().ReverseMap();
                    config.CreateMap<OrderDto, Order>().ReverseMap();
                });
                return mapping;
            }
        }

}
