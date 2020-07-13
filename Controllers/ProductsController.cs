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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        //private readonly IMapper _mapper;
        private readonly IProductWriteRepo _writeRepository;
        public ProductsController(IProductRepo repository, IProductWriteRepo writeRepository)
        {
            _repository = repository;
            //_mapper = mapper;
            _writeRepository = writeRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            var productList = _repository.GetAllProducts();
            if (productList != null)
            {
                //return Ok(_mapper.Map<IEnumerable<ProductReadDtos>>(productList));
                return Ok(productList);
            }
            return NotFound();
            
        }
        [HttpGet("{id}")]
        public ActionResult<Products> GetProductByID(int id)
        {
            var productDetails = _repository.GetProductByID(id);
            if (productDetails != null)
            {
                //return Ok(_mapper.Map<ProductReadDtos>(productDetails));
                return Ok(productDetails);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Products> CreateProduct(ProductUpdateDtos productCreateDtos)
        {
            _writeRepository.CreateProduct(productCreateDtos);

            return Ok();
        }

        [HttpPut("{ProductUpdateDtos}")]
        public ActionResult<ProductUpdateDtos> UpdateProducts(int ProductID, ProductUpdateDtos productUpdateDtos)
        {
            _writeRepository.UpdateProduct(ProductID, productUpdateDtos);
            return NoContent();
        }    
    }
}