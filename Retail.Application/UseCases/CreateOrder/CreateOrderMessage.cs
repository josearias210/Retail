using System;
using System.Collections.Generic;

namespace Retail.Application.UseCases.CreateOrder
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class Delivery
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class CreateOrderMessage
    {
        public Guid OrderId { get; set; }
        public Delivery Delivery { get; set; }
        public IEnumerable<ProductDetail> Products { get; set; }

    }
}

