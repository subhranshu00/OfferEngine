using System;
using System.Collections.Generic;
using Models;

namespace OfferEngine.Data
{
    public interface IPromotionalOfferDetailsReadRepo 
    {
        IEnumerable<PromotionalOfferDetails> GetAllPromotionalOfferDetails();
        PromotionalOfferDetails GetAllPromotionalOfferDetailsByName(string PromotionalOfferName);
    }
}