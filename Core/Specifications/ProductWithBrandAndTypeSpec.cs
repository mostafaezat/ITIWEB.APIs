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
        public ProductWithBrandAndTypeSpec(ProductSpecParams Params) 
            : base(P =>
                (!Params.brandId.HasValue || P.ProductBrandId == Params.brandId.Value) &&
                (!Params.typeId.HasValue || P.ProductTypeId == Params.typeId.Value)
            )
        {
            addingInclude(p => p.ProductBrand);
            addingInclude(p => p.ProductType);

            ApplyPagination(Params.pageSize * (Params.pageIndex - 1), Params.pageSize);

            if (!string.IsNullOrEmpty(Params.sort))
            {
                switch (Params.sort)
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
