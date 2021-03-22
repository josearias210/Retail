using System;

namespace Retail.Application.UseCases.CreateOrder.Exceptions
{
    public class ProductIdOrderProductNeedsAtLeastOneDetailExeption : Exception
    {
        public ProductIdOrderProductNeedsAtLeastOneDetailExeption()
        { }

        public ProductIdOrderProductNeedsAtLeastOneDetailExeption(string message)
            : base(message)
        { }

        public ProductIdOrderProductNeedsAtLeastOneDetailExeption(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
