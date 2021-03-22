using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retail.Core.Domain.Entities;
using System;

namespace Retail.Infrastructure.Data.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");          

            entity.HasData
            (
              new Product(new Guid("3c022e3f-9467-4c28-8aff-a299a0a92001"),"Mouse",40),
              new Product(new Guid("3c022e3f-9467-4c28-8aff-a299a0a92002"), "Monitor", 150)
            );

            var navigation = entity.Metadata.FindNavigation(nameof(Product.Details));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
