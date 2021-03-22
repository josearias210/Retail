using Retail.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Retail.Application.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(Guid id);
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
