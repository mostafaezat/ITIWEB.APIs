using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }     
        public decimal Price { get; set; }  
        public string PictureURL { get; set; }  
        public int ProductBrandId { get; set; }  // int : NOT  Allow null make it Cascade
        public int ProductTypeId { get; set; }  // int : NOT  Allow null make it Cascade
        public ProductBrand ProductBrand { get; set;} // navigational property
        public ProductType ProductType { get; set; } // navigational property
    }
}
