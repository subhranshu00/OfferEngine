using System;
using System.Collections.Generic;
using Models;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace OfferEngine.Data
{
    public interface IProductRepo
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductByID(int id);
    }
}