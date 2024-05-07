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
        public ProductWithBrandAndTypeSpec(string sort, int? brandId, int? typeId) 
            : base(P =>
                (!brandId.HasValue || P.ProductBrandId == brandId.Value) &&
                (!typeId.HasValue || P.ProductTypeId == typeId.Value)
            )
        {
            addingInclude(p => p.ProductBrand);
            addingInclude(p => p.ProductType);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "Price":
                        addingOrder(p => p.Price);
                        break;
                    case "PriceDes":
                        addingOrderDes(p => p.Price);
                        break;
                    case "name":
                        addingOrderDes(p => p.Name);
                        break;
                    default:
                        addingOrder(p => p.Name);
                        break;
                }
            }

        }
        // use for one products 
        public ProductWithBrandAndTypeSpec(int id):base(p => p.Id == id)
        {
            addingInclude(p => p.ProductBrand);
            addingInclude(p => p.ProductType);

        }
    }
}
