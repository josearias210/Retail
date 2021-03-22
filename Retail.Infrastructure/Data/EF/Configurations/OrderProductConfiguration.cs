using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retail.Core.Domain.Entities;

namespace Retail.Infrastructure.Data.EF.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            
            entity.ToTable("OrderProducts");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            entity.Property(e => e.ProductId)
                .IsRequired();

            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

        }
    }
}
