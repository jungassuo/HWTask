using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.ProductAPI.Data;
using PizzaWebApp.ProductAPI.Models;
using PizzaWebApp.ProductAPI.Models.Dtos;
using PizzaWebApp.Services.ProductAPI.Models.Dto;

namespace PizzaWebApp.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
            private readonly AppDbContext _db;
            private ResponseDto _response;
            private IMapper _mapper;

            public ProductAPIController(AppDbContext db, IMapper mapper)
            {
                _db = db;
                _response = new ResponseDto();
                _mapper = mapper;
            }

            [HttpGet]
            public ResponseDto Get()
            {


                try
                {
                    IEnumerable<Product> objList = _db.Product.ToList();
                    _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);

                }
                catch (Exception e)
                {
                    _response.IsSuccess = false;
                    _response.Message = e.Message;
                }
                return _response;
            }

            [HttpGet]
            [Route("{id:int}")]
            public ResponseDto Get(int id)
            {


                try
                {
                    Product obj = _db.Product.FirstOrDefault(e => e.ProductId == id);
                    _response.Result = _mapper.Map<ProductDto>(obj);
                }
                catch (Exception e)
                {
                    _response.IsSuccess = false;
                    _response.Message = e.Message;
                }
                return _response;
            } 
    }
}
