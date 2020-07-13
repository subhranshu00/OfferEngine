using System;

namespace Models
{
    public class PromotionalCategory
    {
        public PromotionalCategory()
        {
            
        }
        private int promotionalCategoryID;
        private string promotionalCategoryName;  

        public int PromotionalCategoryID 
        {
            get
            {
                return promotionalCategoryID;
            }
            set
            {
                promotionalCategoryID = value;
            }
        }
        public string PromotionalCategoryName 
        {
            get
            {
                return promotionalCategoryName;
            }
            set
            {
                promotionalCategoryName = value;
            }
        }


    }
}