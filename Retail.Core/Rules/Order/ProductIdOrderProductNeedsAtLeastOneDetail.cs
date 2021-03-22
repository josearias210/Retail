using Retail.Common.Entities;
using Retail.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Retail.Core.Rule.Order
{
    public class ProductIdOrderProductNeedsAtLeastOneDetail : IBusinessRule
    {
        private readonly IEnumerable<OrderProduct> details;

        public ProductIdOrderProductNeedsAtLeastOneDetail(IEnumerable<OrderProduct> details)
        {
            this.details = details;
        }

        public string Message => "The order needs at least one detail";


        public bool IsBroken()
        {
            return details.Count() == 0;
        }
    }
}
