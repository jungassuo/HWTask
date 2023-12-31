﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.Services.ToppingAPI.Models.Dto;
using PizzaWebApp.ToppingAPI.Data;
using PizzaWebApp.ToppingAPI.Models;
using PizzaWebApp.ToppingAPI.Models.Dtos;

namespace PizzaWebApp.ToppingAPI.Controllers
{
    [Route("api/topping")]
    [ApiController]
    public class ToppingAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ToppingAPIController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Topping> objList = _db.Topping.ToList();
                _response.Result = _mapper.Map<IEnumerable<ToppingDto>>(objList);

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
                Topping obj = _db.Topping.FirstOrDefault(e => e.ToppingId == id);
                _response.Result = _mapper.Map<ToppingDto>(obj);
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
