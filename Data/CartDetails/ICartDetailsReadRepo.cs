using System;
using System.Collections.Generic;
using Models;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace OfferEngine.Data
{
    public interface ICartDetailsReadRepo
    {
        IEnumerable<CartDetails> GetCartDetails(string customerName);
    }
}