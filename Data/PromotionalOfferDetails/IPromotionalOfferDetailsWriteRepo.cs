using System;
using System.Collections.Generic;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public interface IPromotionalOfferDetailsWriteRepo
    {
        bool SaveChanges();
        void CreatePromotionalOfferDetails(PromotionalOfferDetailsDTOs promotionalOfferDetails);
        void UpdatePromotionalOfferDetails(string PromotionalOfferName, PromotionalOfferDetailsDTOs promotionalOfferDetails);
    }
}