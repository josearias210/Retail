using Retail.Common.Entities;

namespace Retail.Core.Rule.Delivery
{
    public class ZipCodeDeliveryIsRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public ZipCodeDeliveryIsRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "zip code delivery is required";


        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(delivery?.ZipCode);
        }
    }
}
