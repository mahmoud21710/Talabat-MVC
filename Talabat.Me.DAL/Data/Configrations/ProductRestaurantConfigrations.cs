using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Me.DAL.Model;

namespace Talabat.Me.DAL.Data.Configrations
{
    public class ProductRestaurantConfigrations : IEntityTypeConfiguration<ProductRestaurant>
    {
        public void Configure(EntityTypeBuilder<ProductRestaurant> builder)
        {
            builder.HasKey( x => new {x.RestaurantsId, x.ProductsId } );

            builder.HasOne<Product>(P => P.Products)
                   .WithMany(S=>S.ProductRestaurant)
                   .HasForeignKey(RS => RS.ProductsId);

            builder.HasOne(R=>R.Restaurants)
                   .WithMany(S => S.ProductRestaurant)
                   .HasForeignKey(RS => RS.RestaurantsId);



        }
    }
}
