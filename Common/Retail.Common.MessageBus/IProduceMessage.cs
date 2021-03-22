namespace Retail.Common.RabbitMQ
{
    public interface IProduceMessage<TMessage, TResult>
    {
        TResult Send(TMessage message);
    }
}
