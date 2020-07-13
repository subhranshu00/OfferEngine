using System;
using System.Collections.Generic;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public interface ICartDetailsWriteRepo
    {
        bool SaveChanges();
        void CreateCartDetails(CartDetails cartDetail);
        void UpdateCartDetails(string customerName, CartDetails cartDetail);
    }
}