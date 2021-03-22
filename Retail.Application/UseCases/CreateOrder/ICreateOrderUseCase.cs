using System.Threading.Tasks;

namespace Retail.Application.UseCases.CreateOrder
{
    public interface ICreateOrderUseCase
    {
        Task ProcessAsync(CreateOrderMessage request);
    }
}