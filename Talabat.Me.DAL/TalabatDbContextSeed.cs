using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Me.DAL.Data.Contexts;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.DAL
{
    public class TalabatDbContextSeed
    {
        public async static Task SeedAsync(TalabatDbContext _context) 
        {
            if (_context.Brands.Count() == 0) 
            {
                var branddata = File.ReadAllText(@"..\Talabat.Me.DAL\Data\DataSeed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);

                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }
            if (_context.Types.Count() == 0) 
            {
                var typesdata = File.ReadAllText(@"..\Talabat.Me.DAL\Data\DataSeed\types.json");

                var types =JsonSerializer.Deserialize<List<productType>>(typesdata);

                if (types is not null && types.Count() > 0) 
                {
                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }
            }
            if (_context.Products.Count() == 0)
            {
                var productdata = File.ReadAllText(@"..\Talabat.Me.DAL\Data\DataSeed\products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productdata);

                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }
            
            if (_context.Restaurants.Count() == 0)
            {
                var restaurantsdata = File.ReadAllText(@"..\Talabat.Me.DAL\Data\DataSeed\restaurants.json");

                var restaurants = JsonSerializer.Deserialize<List<Restaurants>>(restaurantsdata);

                if (restaurants is not null && restaurants.Count() > 0)
                {
                    await _context.Restaurants.AddRangeAsync(restaurants);
                    await _context.SaveChangesAsync();
                }
            }
            
           if(_context.ProductRestaurant.Count() == 0) 
            {
                var ProductRestaurantdata = File.ReadAllText(@"..\Talabat.Me.DAL\Data\DataSeed\ProductRestaurant.json");

                var ProductRestaurants = JsonSerializer.Deserialize<List<ProductRestaurant>>(ProductRestaurantdata);

                if (ProductRestaurants is not null && ProductRestaurants.Count() > 0)
                {
                    await _context.ProductRestaurant.AddRangeAsync(ProductRestaurants);
                    await _context.SaveChangesAsync();
                }
            }     
            
        }
    }
}
