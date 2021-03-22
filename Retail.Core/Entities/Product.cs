using System;
using System.Collections.Generic;

namespace Retail.Core.Domain.Entities
{
    public class Product
    {
        private readonly List<OrderProduct> details;
        public Guid Id { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<OrderProduct> Details => details;

        private Product() { }
        public Product(Guid id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
            details = new List<OrderProduct>(); 
        }
    }
}
