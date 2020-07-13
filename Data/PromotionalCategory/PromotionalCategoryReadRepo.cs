using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace OfferEngine.Data
{
    public class PromotionalCategoryReadRepo : IPromotionalCategoryReadRepo
    {
        private readonly PromotionEngineContext _context;
        public PromotionalCategoryReadRepo(PromotionEngineContext context)
        {
            _context = context;
        }

        public IEnumerable<PromotionalCategory> GetAllPromotionalCategories()
        {
            return _context.PromotionalCategory.ToList();
        }

        public PromotionalCategory GetPromotionalCategoryByID(int categoryID)
        {
            return _context.PromotionalCategory.FirstOrDefault(p => p.PromotionalCategoryID == categoryID);
        }
    }
}