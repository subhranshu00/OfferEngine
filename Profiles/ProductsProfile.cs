using AutoMapper;
using Models;
using DTOs;

namespace Profiles
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {
            //Read data from Products and shows only necessary field to client
            //CreateMap<Products, ProductReadDtos>();
            //Read data from client and write to database
            //CreateMap<ProductReadDtos, Products>();
        }        
    }
}