using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retail.Core.Domain.Entities;

namespace Retail.Infrastructure.Data.EF.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.OwnsOne(m => m.Delivery, a =>
            {
                a.Property(p => p.StreetAddress)
                .HasMaxLength(600)
                .HasColumnName("StreetAddress")
                .IsRequired();

                a.Property(p => p.City)
                .HasMaxLength(150)
                .HasColumnName("City")
                .IsRequired();

                a.Property(p => p.State)
                .HasMaxLength(60)
                .HasColumnName("State")
                .IsRequired();

                a.Property(p => p.ZipCode)
                .HasMaxLength(12)
                .HasColumnName("ZipCode")
                .IsRequired();
            });

            entity.Property(e => e.CreateIn).HasColumnType("datetime");

            var navigation = entity.Metadata.FindNavigation(nameof(Order.Details));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            
        }
    }
}
