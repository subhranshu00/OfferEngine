using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public class CartDetailsReadRepo :  ICartDetailsReadRepo
    {
        private readonly PromotionEngineContext _context;

        public CartDetailsReadRepo(PromotionEngineContext context)
        {
            _context = context;
        }
        public IEnumerable<CartDetails> GetCartDetails(string customerName)
        {
            return _context.CartDetails.Where(c => c.CustomerName == customerName).ToList();
        }
    }
}