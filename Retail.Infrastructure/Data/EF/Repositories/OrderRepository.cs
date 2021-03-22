using System.Threading.Tasks;
using Retail.Application.Data.Repositories;
using Retail.Core.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace Retail.Infrastructure.Data.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RetailDataContext context;
        public OrderRepository(RetailDataContext context) => this.context = context;

        public async Task CreateAsync(Order order) => await this.context.Orders.AddAsync(order);

        public async Task<Order> GetOrderByIdAsync(Guid id) => await this.context.Orders.FirstOrDefaultAsync(x => x.Id == id);

        public Task UpdateAsync(Order order)
        {
            this.context.Orders.Update(order);
            return Task.CompletedTask;
        }
    }
}
