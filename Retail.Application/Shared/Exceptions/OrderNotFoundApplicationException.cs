using System;

namespace Retail.Application.Shared.Exceptions
{
    public class OrderNotFoundApplicationException : Exception
    {
        public OrderNotFoundApplicationException()
        { }

        public OrderNotFoundApplicationException(string message)
            : base(message)
        { }

        public OrderNotFoundApplicationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
