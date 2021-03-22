using Microsoft.EntityFrameworkCore;
using Retail.Application.Data.Repositories;
using Retail.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Infrastructure.Data.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RetailDataContext context;
        public ProductRepository(RetailDataContext context) => this.context = context;

        public async Task<Product> GetProductByIdAsync(Guid id) => await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<IEnumerable<Product>> GetProductByIdAsync(IEnumerable<Guid> ids) => await context.Products.Where(x=> ids.Contains(x.Id)).ToListAsync();
        
    }
}