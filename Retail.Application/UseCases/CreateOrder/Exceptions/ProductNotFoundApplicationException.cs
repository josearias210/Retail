using System;

namespace Retail.Application.UseCases.CreateOrder.Exceptions
{
    public class ProductNotFoundApplicationException : Exception
    {
        public ProductNotFoundApplicationException()
        { }

        public ProductNotFoundApplicationException(string message)
            : base(message)
        { }

        public ProductNotFoundApplicationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
