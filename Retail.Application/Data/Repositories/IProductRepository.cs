using Retail.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Application.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetProductByIdAsync(IEnumerable<Guid> ids);
    }
}
