using System;

namespace Models
{
    public class CartDetailsTotal : CartDetails
    {
        public CartDetailsTotal()
        {
            
        }
        private decimal total;

        public decimal TotalCost 
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
    }
}