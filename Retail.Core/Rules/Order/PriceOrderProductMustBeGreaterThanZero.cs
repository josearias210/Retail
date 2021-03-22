using Retail.Common.Entities;

namespace Retail.Core.Rule.Order
{
    public class PriceOrderProductMustBeGreaterThanZero : IBusinessRule
    {
        private readonly decimal price;

        public PriceOrderProductMustBeGreaterThanZero(decimal price)
        {
            this.price = price;
        }

        public string Message => "Price product must be greater than zero";


        public bool IsBroken()
        {
            return this.price < 0;
        }
    }
}
