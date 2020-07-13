using System;
using System.ComponentModel.DataAnnotations;
using Models;

namespace DTOs
{
    //MultiLevel Inheritance
    public class PromotionalCategoryDTOs : PromotionalCategory, ICommonEntities
    {
        private DateTime _modifiedDate;
        private string _modifiedBy;
        private bool _active;

        public DateTime ModifiedDate
        {
            get
            {
                return _modifiedDate;
            }
            set
            {
                _modifiedDate = Convert.ToDateTime(DateTime.Now);
            }
        }
        public string ModifiedBy
        {
            get
            {
                return _modifiedBy;
            }
            set
            {
                _modifiedBy = "Admin";
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = false;
            }
        }
    }
}

