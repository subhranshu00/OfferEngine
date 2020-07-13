using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Products
    {
        private int _productID;
        private string _productName;
             
        [Key]
        public int ProductID 
        { 
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }            
        }
        [Required]
        [MaxLength(100)]
        public string ProductName 
        {
            get
            {
                return _productName;
            }        
            set
            {
                if (value == null)
                {
                    throw new Exception("Invalid value. Please enter a correct Product Name");
                }
                _productName = value;
            }
        }   
        [Required]
        private decimal _productPrice;
        public decimal ProductPrice 
        {
            get
            {
                return _productPrice;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Invalid value. Please enter a correct Product Price");
                }
                _productPrice = value;
            }
        }     
    }
}