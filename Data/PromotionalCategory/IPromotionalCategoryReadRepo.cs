using System;
using System.Collections.Generic;
using Models;

namespace OfferEngine.Data
{
    public interface IPromotionalCategoryReadRepo 
    {
        IEnumerable<PromotionalCategory> GetAllPromotionalCategories();
        PromotionalCategory GetPromotionalCategoryByID(int categoryID);
    }
}