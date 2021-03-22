using Retail.Application.Data.Repositories;

namespace Retail.Application.Data
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        int Complete();
    }
}