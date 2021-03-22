using System;

namespace Retail.Application.UseCases.UpdateDeliveryOrder
{
    public class DeliveryOrderMessage
    {
        public Guid OrderId { get; set; }
        public string StreetAddress { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get;  set; }
    }
}
