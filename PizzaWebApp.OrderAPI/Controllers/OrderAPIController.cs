using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza_Order_Web_App.OrderAPI.Data;
using PizzaWebApp.OrderAPI.Models;
using PizzaWebApp.OrderAPI.Models.Dtos;
using PizzaWebApp.OrderAPI.Service.IService;
using PizzaWebApp.Services.OrderAPI.Models.Dto;

namespace PizzaWebApp.OrderAPI.Controllers
{
    //Controller is used for getting and posting order objects
    //Getting orders used in Orders list
    //Posting orders used in Shopping cart details to push data to database

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
                    List<OrderDto> orderDtoList = new List<OrderDto>();

                    IEnumerable<OrderDetails> orderDetailsList = _db.OrderDetails.ToList(); ;
                    IEnumerable<OrderHeader> orderHeaderList = _db.OrderHeaders.ToList();
                    IEnumerable<ProductDto> product = await _productService.GetProducts();

                    foreach (OrderHeader header in orderHeaderList)
                    {
                        //Create temporary object for returning the data
                        OrderDto temp = new OrderDto();
                                                
                        temp.OrderHeader = _mapper.Map<OrderHeaderDto>(header);
                        
                        foreach (OrderDetails detail in orderDetailsList)
                        {
                            
                            if (detail.OrderHeaderId == header.OrderHeaderId)
                            {
                                ProductDto tempProduct = product.FirstOrDefault(e => e.ProductId == detail.ProductId);

                                //Check if product exists in db
                                if (tempProduct != null) {
                                    detail.Description = tempProduct.Description;
                                    detail.PizzaName = tempProduct.Name;
                                    detail.Url = tempProduct.ImageUrl;

                                }
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
                    //Saving created object to finalOrder, to use its newly created value in upcoming queries
                    OrderHeader finalOrder = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderDto.OrderHeader)).Entity;
                    await _db.SaveChangesAsync();

                    //Get newly generated OrderHeaderId
                    int getId = finalOrder.OrderHeaderId;

                    //Loop through details objects
                    //Amount of details depends on given property in OrderHeader object called "Count"
                    foreach (OrderDetailsDto detail in orderDto.OrderDetails)
                    {
                        //Set all needed values inside object properties
                        //Details object shows amount of toppings current order has
                        detail.OrderHeaderId = getId;
                        OrderDetails tempDetailsObj = _db.OrderDetails.Add(_mapper.Map<OrderDetails>(detail)).Entity;
                        await _db.SaveChangesAsync();
                        int tempDetailsId = tempDetailsObj.OrderDetailsId;
                        foreach (OrderToppingsDto item in detail.OrderToppings)
                        {
                            item.OrderDetailId = tempDetailsId;
                            _db.OrderToppings.Add(_mapper.Map<OrderToppings>(item));
                        }
                    }
                    await _db.SaveChangesAsync();
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
