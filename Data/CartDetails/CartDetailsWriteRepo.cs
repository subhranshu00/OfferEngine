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
    public class CartDetailsWriteRepo : ICartDetailsWriteRepo, ICartDetailsReadRepo
    {
        private readonly PromotionEngineContext _context;
        private readonly ILogger<CartDetailsWriteRepo> _logger;
        public CartDetailsWriteRepo(PromotionEngineContext context, ILogger<CartDetailsWriteRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void CreateCartDetails(CartDetails cartDetail)
        {
            if (cartDetail == null)
            {
                throw new ArgumentNullException(nameof(cartDetail));
                
            }
            _context.CartDetails.Add(cartDetail);
            SaveChanges();
        }

        public IEnumerable<CartDetails> GetCartDetails(string customerName)
        {
            return _context.CartDetails.Where(c => c.CustomerName == customerName).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        [Obsolete]
        public void UpdateCartDetails(string customerName, CartDetails cartDetail)
        {            
            var customerCartDetails = GetCartDetails(customerName);
            if(customerCartDetails == null)
            {
                _logger.LogInformation("No cart details available");
            }
            var updateCartDetailsText="Update dbo.CartDetails SET ProductID = @ProductID, ProductCount = @ProductCount, DateofPurchase = @DateofPurchase, Active = @Active Where CustomerName = @CustomerNameParam";
            var productID = new SqlParameter("@ProductID", cartDetail.ProductID);
            var productCount = new SqlParameter("@ProductCount", cartDetail.ProductCount);
            var dateofPurchase = new SqlParameter("@DateofPurchase", cartDetail.DateofPurchase);
            var active = new SqlParameter("@Active", cartDetail.Active);
            var nameOfCustomer = new SqlParameter("@CustomerNameParam", cartDetail.CustomerName);
            int noOfRowUpdated = _context.Database.ExecuteSqlCommand(updateCartDetailsText,productID, productCount, dateofPurchase, active, nameOfCustomer);
        }
    }
}