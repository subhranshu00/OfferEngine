using System;

namespace Models
{
    public interface ICommonEntities
    {
        public DateTime ModifiedDate {get; set;}        
        public string ModifiedBy {get; set;}
        public bool Active {get; set;}
    }
}