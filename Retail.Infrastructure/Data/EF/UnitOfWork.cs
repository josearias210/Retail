using Retail.Application.Data;
using Retail.Application.Data.Repositories;
using System;

namespace Retail.Infrastructure.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RetailDataContext orderDataContext;
        public IOrderRepository Order { get; }

        public IProductRepository Product { get; }

        public UnitOfWork(RetailDataContext orderDataContext, IOrderRepository order, IProductRepository product)
        {
            this.Order = order;
            this.Product = product;
            this.orderDataContext = orderDataContext;
        }

        public int Complete() => orderDataContext.SaveChanges();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                orderDataContext.Dispose();
            }
        }
    }
}