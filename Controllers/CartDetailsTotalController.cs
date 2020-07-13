using System;
using System.Collections.Generic;
using AutoMapper;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;
using OfferEngine.Data;

namespace OfferEngine.Controllers
{
    //api/Products
    [Route("api/[controller]")]
    [ApiController()]
    public class CartDetailsTotalController : ControllerBase
    {
        private readonly ITotalCartDetailsReadRepo _repository;
        public CartDetailsTotalController(ITotalCartDetailsReadRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{customerName}")]
        public ActionResult<CartDetailsTotal> GetTotalCartDetails(string customerName)
        {
            var cartDetailsList = _repository.GetTotalCartDetails(customerName);
            if (cartDetailsList != null)
            {
                return Ok(cartDetailsList);
            }
            return NotFound();
        }    
    }
}