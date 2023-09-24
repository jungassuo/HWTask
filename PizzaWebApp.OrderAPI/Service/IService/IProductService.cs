using PizzaWebApp.OrderAPI.Models.Dtos;

namespace PizzaWebApp.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
