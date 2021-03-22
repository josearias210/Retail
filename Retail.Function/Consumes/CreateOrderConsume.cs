using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Retail.Application.UseCases.CreateOrder;
using Retail.Common.Models.Constants;

namespace Retail.Function.Consumes
{
    public class CreateOrderConsume
    {       
        private readonly ICreateOrderUseCase useCase;
        public CreateOrderConsume(ICreateOrderUseCase useCase)
        {
            this.useCase = useCase;
        }

        [FunctionName("CreateOrderConsume")]
        public async Task Run([ServiceBusTrigger(QueueName.CreateOrder, Connection = "ServiceBusConnection")] CreateOrderMessage createOrderMessage, ILogger log)
        {
            log.LogInformation($"Start process for order: {createOrderMessage.OrderId}");
            await useCase.ProcessAsync(createOrderMessage);
            log.LogInformation($"End process for order: {createOrderMessage.OrderId}");
        }  
    }
}
