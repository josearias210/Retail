using Retail.Common.Entities;
using Retail.Core.Domain.Entities.ValueObjects;
using Retail.Core.Rule.Delivery;
using Retail.Core.Rule.Order;
using System;
using System.Collections.Generic;

namespace Retail.Core.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<OrderProduct> details;
        public Guid Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime CreateIn { get; private set; }
        public Delivery Delivery { get; private set; }
        public IReadOnlyCollection<OrderProduct> Details => details;

        private Order()
        {
        }

        public Order(Guid id, DateTime createIn, Delivery delivery)
        {
            this.EnsureDelivery(delivery);

            this.Id = id;
            this.Total = 0;
            this.CreateIn = createIn;
            this.Delivery = delivery;
            this.details = new List<OrderProduct>();
        }

        public void AddDetail(Guid productId, decimal price, string description, int quantity = 1)
        {
            CheckRule(new ProductIdOrderProductMustBeUnique(this, productId));

            details.Add(new OrderProduct(quantity, price, productId, description));
            this.Total += (quantity * quantity);
        }

        public void UpdateDelivery(Delivery delivery)
        {
            this.EnsureDelivery(delivery);
            this.Delivery = delivery;
        }

        private void EnsureDelivery(Delivery delivery)
        {
            CheckRule(new DeliveryIsRequired(delivery));
            CheckRule(new CityDeliveryIsRequired(delivery));
            CheckRule(new StreetAddressDeliveryIsRequired(delivery));
            CheckRule(new StateDeliveryIsRequired(delivery));
            CheckRule(new ZipCodeDeliveryIsRequired(delivery));
        }
    }
}