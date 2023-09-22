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
    [EnableCors("CorsPolicy")]
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
                    Product obj = _db.Product.FirstOrDefault(e => e.Id == id);
                    _response.Result = _mapper.Map<ProductDto>(obj);
                }
                catch (Exception e)
                {
                    _response.IsSuccess = false;
                    _response.Message = e.Message;
                }
                return _response;
            }

            [HttpPost]
            //[Authorize(Roles = "ADMIN")]
            public ResponseDto Post([FromBody] ProductDto roomdto)
            {


                try
                {
                    Product room = _mapper.Map<Product>(roomdto);
                    _db.Product.Add(room);
                    _db.SaveChanges();

                    _response.Result = _mapper.Map<ProductDto>(room);
                }
                catch (Exception e)
                {
                    _response.IsSuccess = false;
                    _response.Message = e.Message;
                }
                return _response;
            }


            [HttpPut]
            //[Authorize(Roles = "ADMIN")]
            public ResponseDto Put([FromBody] ProductDto roomdto)
            {


                try
                {
                    Product room = _mapper.Map<Product>(roomdto);
                    _db.Product.Update(room);
                    _db.SaveChanges();

                    _response.Result = _mapper.Map<ProductDto>(room);

                }
                catch (Exception e)
                {
                    _response.IsSuccess = false;
                    _response.Message = e.Message;
                }
                return _response;
            }


            [HttpDelete]
            [Route("{id:int}")]
            //[Authorize(Roles = "ADMIN")]
            public ResponseDto Delete(int id)
            {
                try
                {
                    Product room = _db.Product.First(u => u.Id == id);
                    _db.Product.Remove(room);
                    _db.SaveChanges();
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
