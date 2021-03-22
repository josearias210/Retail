using Retail.Application.Data;
using Retail.Application.Shared.Exceptions;
using System.Threading.Tasks;

namespace Retail.Application.UseCases.UpdateDeliveryOrder
{
    public class UpdateDeliveryOrderUseCase : IUpdateDeliveryOrderUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateDeliveryOrderUseCase(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;


        public async Task ProcessAsync(DeliveryOrderMessage request)
        {
            var order = await this.unitOfWork.Order.GetOrderByIdAsync(request.OrderId);
            if (order == null)
            {
                throw new OrderNotFoundApplicationException($"The order {request.OrderId} not found");
            }

            order.UpdateDelivery(new Core.Domain.Entities.ValueObjects.Delivery(request.StreetAddress, request.City, request.State,request.ZipCode));
            await unitOfWork.Order.UpdateAsync(order);
            this.unitOfWork.Complete();

        }
    }
}
