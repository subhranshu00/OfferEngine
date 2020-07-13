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
    public class PromotionalOfferDetailsWriteRepo : IPromotionalOfferDetailsWriteRepo, IPromotionalOfferDetailsReadRepo
    {
        private readonly PromotionEngineContext _context;
        private readonly ILogger<PromotionalOfferDetailsWriteRepo> _logger;
        public PromotionalOfferDetailsWriteRepo(PromotionEngineContext context, ILogger<PromotionalOfferDetailsWriteRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void CreatePromotionalOfferDetails(PromotionalOfferDetailsDTOs promotionalOfferDetails)
        {
            if (promotionalOfferDetails == null)
            {
                throw new ArgumentNullException(nameof(promotionalOfferDetails));
                
            }
            _context.PromotionalOfferDetails.Add(promotionalOfferDetails);
            SaveChanges();
        }

        public IEnumerable<PromotionalOfferDetails> GetAllPromotionalOfferDetails()
        {
            return _context.PromotionalOfferDetails.ToList();
        }

        public PromotionalOfferDetails GetAllPromotionalOfferDetailsByName(string PromotionalOfferName)
        {
            return _context.PromotionalOfferDetails.FirstOrDefault(p => p.PromotionalOfferName == PromotionalOfferName);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        [Obsolete]
        public void UpdatePromotionalOfferDetails(string PromotionalOfferName, PromotionalOfferDetailsDTOs promotionalOfferDetails)
        {            
            var promotionalOfferDetailAvailable = GetAllPromotionalOfferDetailsByName(PromotionalOfferName);
            if(promotionalOfferDetailAvailable == null)
            {
                _logger.LogInformation("No Promotional offer details available");
            }
            var updatePromotionalOfferText="Update dbo.PromotionalOfferDetails SET PromotionalOfferName = @PromotionalOfferName, PromotionalOfferDetail = @PromotionalOfferDetail, StartDate = @StartDate, EndDate = @EndDate, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy, Active = @Active Where PromotionalOfferName = @PromotionalOfferName";
            var promotionalOfferName = new SqlParameter("@PromotionalOfferName",PromotionalOfferName);
            var promotionalOfferDetail = new SqlParameter("@PromotionalOfferDetail", promotionalOfferDetails.PromotionalOfferDetail);
            var startDate = new SqlParameter("@StartDate", promotionalOfferDetails.StartDate);
            var endDate = new SqlParameter("@EndDate", promotionalOfferDetails.EndDate);
            var active = new SqlParameter("@Active",promotionalOfferDetails.Active);
            var modifiedDate = new SqlParameter("@ModifiedDate",DateTime.Now);
            var modifiedBy = new SqlParameter("@ModifiedBy","Admin");
            var promotionalOfferNameParam = new SqlParameter("@promotionalOfferNameParam",PromotionalOfferName);
            int noOfRowUpdated = _context.Database.ExecuteSqlCommand(updatePromotionalOfferText,promotionalOfferName, promotionalOfferDetail, startDate, endDate, active, modifiedDate, modifiedBy, promotionalOfferNameParam);
        }
    }
}