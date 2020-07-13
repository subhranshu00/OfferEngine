using System;

namespace Models
{
    public class CartDetails
    {
        public CartDetails()
        {
            
        }
        private int cartID;
        private string customerName;  
        private int productID;
        private int productCount;
        private DateTime dateofPurchase;
        private bool active;
        private bool finalized;

        public int CartID 
        {
            get
            {
                return cartID;
            }
            set
            {
                cartID = value;
            }
        }
        public string CustomerName 
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
            }
        }
        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
            }
        }
        public int ProductCount
        {
            get
            {
                return productCount;
            }
            set
            {
                productCount = value;
            }
        }
        public DateTime DateofPurchase
        {
            get
            {
                return dateofPurchase;
            }
            set
            {
                dateofPurchase = value;
            }
        }
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        public bool Finalized
        {
            get
            {
                return finalized;
            }
            set
            {
                finalized = value;
            }
        }
    }
}