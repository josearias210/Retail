using Retail.Common.Entities;

namespace Retail.Core.Rule.Order
{
    public class QuantityOrderProductMustBeGreaterThanZero : IBusinessRule
    {
        private readonly int quantity;

        public QuantityOrderProductMustBeGreaterThanZero(int quantity)
        {
            this.quantity = quantity;
        }

        public string Message => "Quantity must be greater than zero";


        public bool IsBroken()
        {
            return this.quantity < 0;
        }
    }
}
