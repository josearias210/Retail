using Retail.Common.Entities;

namespace Retail.Core.Rule.Delivery
{
    public class StreetAddressDeliveryIsRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public StreetAddressDeliveryIsRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "Street address delivery is required";


        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(delivery?.StreetAddress);
        }
    }
}
