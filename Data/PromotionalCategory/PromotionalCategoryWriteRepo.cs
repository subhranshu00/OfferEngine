using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace OfferEngine.Data
{
    //Multiple Inheritance
    public class PromotionalCategoryWriteRepo : IPromotionalCategoryWriteRepo, IPromotionalCategoryReadRepo
    {
        private readonly PromotionEngineContext _context;
        private readonly ILogger<PromotionalCategoryWriteRepo> _logger;
        public PromotionalCategoryWriteRepo(PromotionEngineContext context, ILogger<PromotionalCategoryWriteRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void CreatePromotionalCategory(PromotionalCategoryDTOs promotionalCategories)
        {
            if (promotionalCategories == null)
            {
                throw new ArgumentNullException(nameof(promotionalCategories));
                
            }
            _context.PromotionalCategory.Add(promotionalCategories);
            SaveChanges();
        }

        public IEnumerable<PromotionalCategory> GetAllPromotionalCategories()
        {
            return _context.PromotionalCategory.ToList();
        }

        public PromotionalCategory GetPromotionalCategoryByID(int categoryID)
        {
            return _context.PromotionalCategory.FirstOrDefault(p => p.PromotionalCategoryID == categoryID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        [Obsolete]
        public void UpdatePromotionalCategory(int PromotionalCategoryID, PromotionalCategoryDTOs promotionalCategories)
        {            
            var promoCategories = GetPromotionalCategoryByID(PromotionalCategoryID);
            if(promoCategories == null)
            {
                _logger.LogInformation("No Promotional Categories available");
            }
            var updatePromotionalCategoryText="Update dbo.PromotionalCategory SET PromotionalCategoryName = @PromotionalCategoryName, Active = @Active, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy Where PromotionalCategoryID = @PromotionalCategoryIDParam";
            var PromotionalCategoryName = new SqlParameter("@PromotionalCategoryName",promotionalCategories.PromotionalCategoryName);
            var Active = new SqlParameter("@Active",promotionalCategories.Active);
            var ModifiedDate = new SqlParameter("@ModifiedDate",DateTime.Now);
            var ModifiedBy = new SqlParameter("@ModifiedBy","Admin");
            var PromotionalCategoryIDParam = new SqlParameter("@PromotionalCategoryIDParam",PromotionalCategoryID);
            int noOfRowUpdated = _context.Database.ExecuteSqlCommand(updatePromotionalCategoryText,PromotionalCategoryName, Active, ModifiedDate, ModifiedBy, PromotionalCategoryIDParam);
        }
    }
}