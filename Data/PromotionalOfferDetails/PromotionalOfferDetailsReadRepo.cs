using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace OfferEngine.Data
{
    public class PromotionalOfferDetailsReadRepo : IPromotionalOfferDetailsReadRepo
    {
        private readonly PromotionEngineContext _context;
        public PromotionalOfferDetailsReadRepo(PromotionEngineContext context)
        {
            _context = context;
        }

        public IEnumerable<PromotionalOfferDetails> GetAllPromotionalOfferDetails()
        {
            return _context.PromotionalOfferDetails.ToList();
        }

        public PromotionalOfferDetails GetAllPromotionalOfferDetailsByName(string PromotionalOfferName)
        {
            return _context.PromotionalOfferDetails.FirstOrDefault(p => p.PromotionalOfferName == PromotionalOfferName);
        }
    }
}