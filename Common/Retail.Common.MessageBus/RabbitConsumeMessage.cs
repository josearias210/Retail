using Newtonsoft.Json;
using RabbitMQ.Client;
using Retail.Common.Models.Settings;
using Retail.Common.RabbitMQ.Models;
using Retail.Common.Serializer;
using System;
using System.Text;

namespace Retail.Common.RabbitMQ
{
    public class RabbitConsumeMessage<TMessage, TResult> : IDisposable
    {
        private readonly IModel channel;
        private readonly string queueName;
        private readonly IConnection connection;
        private readonly ISerializer serializer;

        public RabbitConsumeMessage(RabbitMQSettings settings, ISerializer serializer, string queueName)
        {
            this.serializer = serializer;
            this.queueName = queueName;

            var factory = new ConnectionFactory() { HostName = settings.Hostname, UserName = settings.Username, Password = settings.Password };

            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        public MessageResult<TResult> Listen(MessageRequest message)
        {
            IBasicProperties props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            //var messageBytes = JsonConvert.SerializeObject(message);
           // byte[] customerBuffer = Encoding.UTF8.GetBytes(messageBytes);

            var messageBytes = serializer.SerializeObjectToByteArray(message);

            channel.QueueDeclare(queue: queueName,
                          durable: false,
                          exclusive: false,
                          autoDelete: false,
                          arguments: null);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: queueName,
                basicProperties: null,
                body: messageBytes);

            return new MessageResult<TResult>() { IsSuccess = true };
        }

        public void Dispose()
        {
            channel.Close();
            connection.Close();
        }

    }
}