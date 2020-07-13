using System;
using System.Collections.Generic;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public interface IPromotionalCategoryWriteRepo
    {
        bool SaveChanges();
        void CreatePromotionalCategory(PromotionalCategoryDTOs promotionalCategories);
        void UpdatePromotionalCategory(int PromotionalCategoryID, PromotionalCategoryDTOs promotionalCategories);
    }
}