using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Retail.Application.UseCases.UpdateDeliveryOrder;
using Retail.Common.Models.Constants;

namespace Retail.Function.Consumes
{
    public class UpdateDeliveryOrderConsume
    {        
        private readonly IUpdateDeliveryOrderUseCase useCase;
        public UpdateDeliveryOrderConsume(IUpdateDeliveryOrderUseCase useCase)
        {
            this.useCase = useCase;
        }

        [FunctionName("UpdateDeliveryOrderConsume")]
        public async Task Run([ServiceBusTrigger(QueueName.UpdateDeliveryOrder, Connection = "ServiceBusConnection")] DeliveryOrderMessage deliveryOrderMessage, ILogger log)
        {
            log.LogInformation($"Start process for order: {deliveryOrderMessage.OrderId}");
            await useCase.ProcessAsync(deliveryOrderMessage);
            log.LogInformation($"End process for order: {deliveryOrderMessage.OrderId}");
        }
       
    }
}
