using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypeSpec : BaseSpecifications<Product>
    {
        // use for all products 
        public ProductWithBrandAndTypeSpec()
        {
            addingInclude(p => p.ProductBrand);
            addingInclude(p => p.ProductType);

        }
        // use for one products 
        public ProductWithBrandAndTypeSpec(int id):base(p => p.Id == id)
        {
            addingInclude(p => p.ProductBrand);
            addingInclude(p => p.ProductType);

        }
    }
}
