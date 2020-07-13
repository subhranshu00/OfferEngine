using System;
using System.Collections.Generic;
using Models;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace OfferEngine.Data
{
    public interface ITotalCartDetailsReadRepo
    {
        IEnumerable<CartDetailsTotal> GetTotalCartDetails(string customerName);
    }
}