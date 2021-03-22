using System.Threading.Tasks;

namespace Retail.Application.UseCases.UpdateDeliveryOrder
{
    public interface IUpdateDeliveryOrderUseCase
    {
        Task ProcessAsync(DeliveryOrderMessage request);
    }
}
