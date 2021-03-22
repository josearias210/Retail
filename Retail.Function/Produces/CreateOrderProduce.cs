using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Retail.Common.Models.Constants;
using Newtonsoft.Json;
using Retail.Application.UseCases.CreateOrder;

namespace Retail.Function.Produces
{
    public class CreateOrderProduce
    {
        [FunctionName("CreateOrderProduce")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequest req, [ServiceBus(QueueName.CreateOrder, Connection = "ServiceBusConnection")] IAsyncCollector<CreateOrderMessage> outputEvents, ILogger log)
        {
            log.LogInformation($"Start process for order: {req.Body}");
            var content = await new StreamReader(req.Body).ReadToEndAsync(); 
            var message = JsonConvert.DeserializeObject<CreateOrderMessage>(content);
            await outputEvents.AddAsync(message);
        }
    }
}