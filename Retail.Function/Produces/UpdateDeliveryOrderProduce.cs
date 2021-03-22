using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Retail.Common.Models.Constants;
using Newtonsoft.Json;
using Retail.Application.UseCases.UpdateDeliveryOrder;
using System;
using Retail.Function.ViewModels;

namespace Retail.Function.Produces
{
    public class UpdateDeliveryOrderProduce
    {
        [FunctionName("UpdateDeliveryOrderProduce")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "orders/{orderId}/delivery")] HttpRequest req, Guid orderId, [ServiceBus(QueueName.UpdateDeliveryOrder, Connection = "ServiceBusConnection")] IAsyncCollector<DeliveryOrderMessage> outputEvents, ILogger log)
        {
            log.LogInformation($"Start process for update delivery order: {orderId} {req.Body}");
            log.LogInformation($"New Delivery {req.Body}");
            var content = await new StreamReader(req.Body).ReadToEndAsync();  
            var request = JsonConvert.DeserializeObject<DeliveryOrderRequest>(content);
            await outputEvents.AddAsync(new DeliveryOrderMessage() 
            { 
                OrderId = orderId,
                City = request.City,
                State = request.State,
                StreetAddress = request.StreetAddress,
                ZipCode = request.ZipCode
            });
        }
    }
}