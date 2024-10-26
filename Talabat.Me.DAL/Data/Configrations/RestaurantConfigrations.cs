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
    public class RestaurantConfigrations : IEntityTypeConfiguration<Restaurants>
    {
        public void Configure(EntityTypeBuilder<Restaurants> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(X=>X.PhoneNumber).IsRequired().HasMaxLength(200);

            builder.Property(x => x.PictureUrl).IsRequired();
        }
    }
}
