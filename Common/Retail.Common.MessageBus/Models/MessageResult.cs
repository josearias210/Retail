using System.Collections.Generic;

namespace Retail.Common.RabbitMQ.Models
{
    public class MessageResult<T>
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Result { get; set; }

    }
}
