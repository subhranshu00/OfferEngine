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
    public class PromotionalOfferDetailsController : ControllerBase
    {
        private readonly IPromotionalOfferDetailsReadRepo _repository;
        private readonly IPromotionalOfferDetailsWriteRepo _writeRepository;
        public PromotionalOfferDetailsController(IPromotionalOfferDetailsReadRepo repository, IPromotionalOfferDetailsWriteRepo writeRepository)
        {
            _repository = repository;
            _writeRepository = writeRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PromotionalOfferDetails>> GetAllPromotionalOfferDetails()
        {
            var promotionalOfferDetailsList = _repository.GetAllPromotionalOfferDetails();
            if (promotionalOfferDetailsList != null)
            {
                return Ok(promotionalOfferDetailsList);
            }
            return NotFound();
            
        }
        [HttpGet("{PromotionalOfferName}")]
        public ActionResult<PromotionalOfferDetails> GetAllPromotionalOfferDetailsByName(string PromotionalOfferName)
        {
            var promotionalOfferDetailsList = _repository.GetAllPromotionalOfferDetailsByName(PromotionalOfferName);
            if (promotionalOfferDetailsList != null)
            {
                return Ok(promotionalOfferDetailsList);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PromotionalOfferDetails> CreatePromotionalOfferDetails(PromotionalOfferDetailsDTOs promotionalOfferDetails)
        {
            _writeRepository.CreatePromotionalOfferDetails(promotionalOfferDetails);

            return Ok();
        }

        [HttpPut("{PromotionalOfferDetailsDTOs}")]
        public ActionResult<PromotionalOfferDetailsDTOs> UpdatePromotionalOfferDetails(string PromotionalOfferName, PromotionalOfferDetailsDTOs promotionalOfferDetails)
        {
            _writeRepository.UpdatePromotionalOfferDetails(PromotionalOfferName, promotionalOfferDetails);
            return NoContent();
        }    
    }
}