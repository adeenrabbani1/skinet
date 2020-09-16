using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        //we want to declare a static method, to which 
        //we can call later to seed the data.

        public static async Task SeedData(StoreContext context, ILoggerFactory logger)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {

                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();

                }

                if (!context.ProductTypes.Any())
                {

                    var brandsTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var brandTypes = JsonSerializer.Deserialize<List<ProductType>>(brandsTypeData);
                    foreach (var item in brandTypes)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();

                }
                if (!context.Products.Any())
                {

                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();

                }

            }
            catch (Exception ex)
            {

                var log = logger.CreateLogger<StoreContextSeed>();
                log.LogError(ex.Message);
            }

        }
    }
}