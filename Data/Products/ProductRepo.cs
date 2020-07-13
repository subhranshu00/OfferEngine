using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public class ProductRepo :  IProductRepo
    {
        private readonly PromotionEngineContext _context;

        public ProductRepo(PromotionEngineContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Products GetProductByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}