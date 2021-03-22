using System;

namespace Retail.Application.UseCases.CreateOrder.Exceptions
{
    public class OrderNeedsDeliveryApplicationException : Exception
    {
        public OrderNeedsDeliveryApplicationException()
        { }

        public OrderNeedsDeliveryApplicationException(string message)
            : base(message)
        { }

        public OrderNeedsDeliveryApplicationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
