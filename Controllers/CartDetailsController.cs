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
    public class CartDetailsController : ControllerBase
    {
        private readonly ICartDetailsReadRepo _repository;
        private readonly ICartDetailsWriteRepo _writeRepository;
        public CartDetailsController(ICartDetailsReadRepo repository, ICartDetailsWriteRepo writeRepository)
        {
            _repository = repository;
            _writeRepository = writeRepository;
        }
        
        [HttpGet("{customerName}")]
        public ActionResult<CartDetails> GetCartDetails(string customerName)
        {
            var cartDetailsList = _repository.GetCartDetails(customerName);
            if (cartDetailsList != null)
            {
                return Ok(cartDetailsList);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CartDetails> CreateCartDetails(CartDetails cartDetail)
        {
            _writeRepository.CreateCartDetails(cartDetail);

            return Ok();
        }

        [HttpPut("{cartDetail}")]
        public ActionResult<CartDetails> UpdateCartDetails(string customerName, CartDetails cartDetail)
        {
            _writeRepository.UpdateCartDetails(customerName, cartDetail);
            return NoContent();
        }    
    }
}