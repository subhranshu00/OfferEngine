using Microsoft.EntityFrameworkCore;
using Models;
using DTOs;

namespace OfferEngine.Data
{
    public class PromotionEngineContext:DbContext
    {
        public PromotionEngineContext(DbContextOptions<PromotionEngineContext> opt): base(opt)
        {
            
        }

        //Products Table
        public DbSet<Products> Products {get; set;}
        //PromotionalCategory Table
        public DbSet<PromotionalCategory> PromotionalCategory {get; set;}
        public DbSet<PromotionalOfferDetails> PromotionalOfferDetails {get; set;}
        public DbSet<CartDetails> CartDetails {get; set;}
        public DbSet<CartDetailsTotal> CartDetailsTotal {get; set;}
    }
}