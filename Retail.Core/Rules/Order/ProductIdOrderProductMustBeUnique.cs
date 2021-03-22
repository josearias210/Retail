using Retail.Common.Entities;
using System;
using System.Linq;

namespace Retail.Core.Rule.Order
{
    public class ProductIdOrderProductMustBeUnique : IBusinessRule
    {
        private readonly Domain.Entities.Order order;
        private readonly Guid productId;

        public ProductIdOrderProductMustBeUnique(Domain.Entities.Order order, Guid productId)
        {
            this.order = order;
            this.productId = productId;
        }

        public string Message => $"The product {productId} is duplicated";


        public bool IsBroken()
        {
            return order.Details.Any(x => x.ProductId == productId);
        }
    }
}
