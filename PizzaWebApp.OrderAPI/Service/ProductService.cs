using Newtonsoft.Json;
using PizzaWebApp.OrderAPI.Models.Dtos;
using PizzaWebApp.OrderAPI.Service.IService;
using PizzaWebApp.Services.OrderAPI.Models.Dto;

namespace PizzaWebApp.OrderAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));;
            }
            return new List<ProductDto>();
        }
    }
}
