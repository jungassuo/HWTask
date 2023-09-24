using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza_Order_Web_App.OrderAPI.Data;
using PizzaWebApp.OrderAPI.Models;
using PizzaWebApp.OrderAPI.Models.Dtos;
using PizzaWebApp.OrderAPI.Service.IService;
using PizzaWebApp.Services.OrderAPI.Models.Dto;
using System.Collections.Generic;

namespace PizzaWebApp.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
            private readonly AppDbContext _db;
            private ResponseDto _response;
            private IMapper _mapper;
            private IProductService _productService;

            public OrderAPIController(AppDbContext db, IMapper mapper, IProductService productService)
            {
                _db = db;
                _response = new ResponseDto();
                _mapper = mapper;
                _productService = productService;
            }

            [HttpGet]
            public async Task<ResponseDto> Get()
            {
                try
                {
                    IEnumerable<OrderDetails> orderDetailsList;

                    orderDetailsList = _db.OrderDetails.ToList();

                    IEnumerable<OrderHeader> orderHeaderList;

                    orderHeaderList = _db.OrderHeaders.ToList();

                    List<OrderDto> orderDtoList = new List<OrderDto>();

                    IEnumerable<ProductDto> product = await _productService.GetProducts();

                    foreach (OrderHeader header in orderHeaderList)
                    {
                        OrderDto temp = new OrderDto();
                                                
                        temp.OrderHeader = _mapper.Map<OrderHeaderDto>(header);
                        
                        foreach (OrderDetails detail in orderDetailsList)
                        {
                            if (detail.OrderHeaderId == header.OrderHeaderId)
                            {
                                ProductDto tempProduct = product.FirstOrDefault(e => e.ProductId == detail.ProductId);
                                detail.Description = tempProduct.Description;
                                detail.PizzaName = tempProduct.Name;
                                detail.Url = tempProduct.ImageUrl;
                                temp.OrderDetails.Add(_mapper.Map<OrderDetailsDto>(detail));
                            }
                        }
                        orderDtoList.Add(temp);
                    }

                    _response.Result = orderDtoList;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
        }

            

            [HttpPost]
            public async Task<ResponseDto> Post([FromBody] OrderDto orderDto)
            {
                
                try
                {
                    OrderHeader finalOrder = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderDto.OrderHeader)).Entity;

                await _db.SaveChangesAsync();

                int getId = finalOrder.OrderHeaderId;

                foreach (OrderDetailsDto detail in orderDto.OrderDetails)
                {
                    detail.OrderHeaderId = getId;
                    _db.OrderDetails.Add(_mapper.Map<OrderDetails>(detail));
                    await _db.SaveChangesAsync();
                }

                //foreach (OrderToppingsDto topping in orderDto.OrderToppings)
                //{
                //    _db.OrderToppings.Add(_mapper.Map<OrderToppings>(topping));
                //}

                //await _db.SaveChangesAsync();

                _response.Result = orderDto;

                }
                catch (Exception ex)
                {

                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return _response;
            }


        
    }
}
