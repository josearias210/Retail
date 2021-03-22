using Retail.Common.Entities;

namespace Retail.Core.Rule.Delivery
{
    public class StateDeliveryIsRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public StateDeliveryIsRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "State delivery is required";


        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(delivery?.State);
        }
    }
}
