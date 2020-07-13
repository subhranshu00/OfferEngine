using System;

namespace Models
{
    public class PromotionalOfferDetails
    {
        public PromotionalOfferDetails()
        {
            
        }
        private int promotionalOfferID;
        private string promotionalOfferName;  
        private string promotionalOfferDetail;
        private DateTime startDate;
        private DateTime endDate;

        public int PromotionalOfferID 
        {
            get
            {
                return promotionalOfferID;
            }
            set
            {
                promotionalOfferID = value;
            }
        }
        public string PromotionalOfferName 
        {
            get
            {
                return promotionalOfferName;
            }
            set
            {
                promotionalOfferName = value;
            }
        }
        public string PromotionalOfferDetail
        {
            get
            {
                return promotionalOfferDetail;
            }
            set
            {
                promotionalOfferDetail = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

    }
}