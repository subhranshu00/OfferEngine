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
    public class PromotionalCategoriesController : ControllerBase
    {
        private readonly IPromotionalCategoryReadRepo _repository;
        private readonly IPromotionalCategoryWriteRepo _writeRepository;
        public PromotionalCategoriesController(IPromotionalCategoryReadRepo repository, IPromotionalCategoryWriteRepo writeRepository)
        {
            _repository = repository;
            _writeRepository = writeRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PromotionalCategory>> GetAllPromotionalCategories()
        {
            var promotionalCategoriesList = _repository.GetAllPromotionalCategories();
            if (promotionalCategoriesList != null)
            {
                return Ok(promotionalCategoriesList);
            }
            return NotFound();
            
        }
        [HttpGet("{id}")]
        public ActionResult<PromotionalCategory> GetPromotionalCategoryByID(int id)
        {
            var promotionalCategoriesList = _repository.GetPromotionalCategoryByID(id);
            if (promotionalCategoriesList != null)
            {
                return Ok(promotionalCategoriesList);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PromotionalCategory> CreatePromotionalCategory(PromotionalCategoryDTOs promotionalCategoryDTOs)
        {
            _writeRepository.CreatePromotionalCategory(promotionalCategoryDTOs);

            return Ok();
        }

        [HttpPut("{PromotionalCategoryDTOs}")]
        public ActionResult<PromotionalCategoryDTOs> UpdatePromotionalCategory(int promotionalCategoryID, PromotionalCategoryDTOs promotionalCategoryDTOs)
        {
            _writeRepository.UpdatePromotionalCategory(promotionalCategoryID, promotionalCategoryDTOs);
            return NoContent();
        }    
    }
}