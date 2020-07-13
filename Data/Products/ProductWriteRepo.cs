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
    public class ProductWriteRepo : IProductWriteRepo, IProductRepo
    {
        private readonly PromotionEngineContext _context;
        private readonly ILogger<ProductWriteRepo> _logger;
        public ProductWriteRepo(PromotionEngineContext context, ILogger<ProductWriteRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void CreateProduct(ProductUpdateDtos products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
                
            }
            _context.Products.Add(products);
            SaveChanges();
        }

        public IEnumerable<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Products GetProductByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        [Obsolete]
        public void UpdateProduct(int ProductID, ProductUpdateDtos products)
        {            
            var updateProducts = GetProductByID(ProductID);
            if(updateProducts == null)
            {
                _logger.LogInformation("No Product available");
            }
            var updateProductText="Update dbo.Products SET ProductName = @ProductName, ProductPrice = @ProductPrice, Active = @Active, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy Where ProductID = @ProductIDParam";
            var ProductName = new SqlParameter("@ProductName",products.ProductName);
            var ProductPrice = new SqlParameter("@ProductPrice",products.ProductPrice);
            var Active = new SqlParameter("@Active",products.Active);
            var ModifiedDate = new SqlParameter("@ModifiedDate",DateTime.Now);
            var ModifiedBy = new SqlParameter("@ModifiedBy","Admin");
            var ProductIDParam = new SqlParameter("@ProductIDParam",ProductID);
            int noOfRowUpdated = _context.Database.ExecuteSqlCommand(updateProductText,ProductName, ProductPrice, Active, ModifiedDate, ModifiedBy, ProductIDParam);
        }
    }
}