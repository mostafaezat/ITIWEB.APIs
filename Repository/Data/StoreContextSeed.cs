using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try {  
                if(!context.ProductBrands.Any())
                {
                var brandsData = File.ReadAllText("../Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands!)
                    {
                        context.Set<ProductBrand>().Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var TypesData = File.ReadAllText("../Repository/Data/DataSeed/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    foreach (var item in Types!)
                    {
                        context.Set<ProductType>().Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../Repository/Data/DataSeed/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    foreach (var item in Products!)
                    {
                        context.Set<Product>().Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, ex.Message);
            }
        }
    }
}
