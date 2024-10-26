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
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).HasMaxLength(200).IsRequired();
            builder.Property(P=>P.PictureUrl).IsRequired();

            builder.Property(P=>P.Price).HasColumnType("decimal(18.2)");

            builder.HasOne(P=>P.Brand)
                   .WithMany()
                   .HasForeignKey(P=>P.BrandId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p=>p.Type)
                   .WithMany()
                   .HasForeignKey(p=>p.TypeId)
                   .OnDelete(DeleteBehavior.SetNull);

            
        }
    }
}
