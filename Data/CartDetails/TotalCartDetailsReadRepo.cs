using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace OfferEngine.Data
{
    public class TotalCartDetailsReadRepo :  ITotalCartDetailsReadRepo
    {
        private readonly PromotionEngineContext _context;

        public TotalCartDetailsReadRepo(PromotionEngineContext context)
        {
            _context = context;
        }
        [Obsolete]
        public IEnumerable<CartDetailsTotal> GetTotalCartDetails(string customerName)
        {
            List<CartDetailsTotal> _cartDetailsTotal = new List<CartDetailsTotal>();
            _cartDetailsTotal = _context.CartDetailsTotal.FromSql<CartDetailsTotal>("exec CartDetailsTotal @CustomerName ", customerName).ToList<CartDetailsTotal>();
            return _cartDetailsTotal;
        }
    }
}