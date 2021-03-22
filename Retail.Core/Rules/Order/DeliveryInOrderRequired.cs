using Retail.Common.Entities;

namespace Retail.Core.Rule.Order
{
    public class DeliveryInOrderRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public DeliveryInOrderRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "Description is required";


        public bool IsBroken()
        {
            return delivery == null;
        }
    }
}
