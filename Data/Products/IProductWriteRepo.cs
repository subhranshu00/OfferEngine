using System;
using System.Collections.Generic;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public interface IProductWriteRepo
    {
        bool SaveChanges();
        void CreateProduct(ProductUpdateDtos products);
        void UpdateProduct(int ProductID, ProductUpdateDtos products);
    }
}