using Retail.Common.Entities;

namespace Retail.Core.Rule.Delivery
{
    public class CityDeliveryIsRequired : IBusinessRule
    {
        private readonly Domain.Entities.ValueObjects.Delivery delivery;

        public CityDeliveryIsRequired(Domain.Entities.ValueObjects.Delivery delivery)
        {
            this.delivery = delivery;
        }

        public string Message => "City delivery is required";


        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(delivery?.City);
        }
    }
}
