using Microsoft.EntityFrameworkCore;
using Retail.Core.Domain.Entities;
using Retail.Infrastructure.Data.EF.Configurations;

namespace Retail.Infrastructure.Data.EF
{
    public class RetailDataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Product> Products { get; set; }

        public RetailDataContext(DbContextOptions<RetailDataContext> options)
        : base(options)
        {
        }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
