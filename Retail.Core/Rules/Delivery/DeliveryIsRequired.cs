using Retail.Common.Entities;

namespace Retail.Core.Rule.Delivery
{
    public class DeliveryIsRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public DeliveryIsRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "delivery is required";


        public bool IsBroken()
        {
            return delivery == null;
        }
    }
}
