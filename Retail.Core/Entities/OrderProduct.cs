using Retail.Common.Entities;
using Retail.Core.Rule.Order;
using System;

namespace Retail.Core.Domain.Entities
{
    public class OrderProduct : Entity
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal Total { get; private set; }

        private OrderProduct() { }
        public OrderProduct(int quantity, decimal price, Guid productId, string description)
        {
            CheckRule(new PriceOrderProductMustBeGreaterThanZero(price));
            CheckRule(new DescriptionOrderProductIsRequired(description));
            CheckRule(new QuantityOrderProductMustBeGreaterThanZero(quantity));

            Id = Guid.NewGuid();
            Quantity = quantity;
            Price = price;
            ProductId = productId;
            Description = description;
            Total = price * quantity;
        }

    }
}
