using Retail.Common.Entities;
using System.Collections.Generic;

namespace Retail.Core.Domain.Entities.ValueObjects
{
    public class Delivery : ValueObject
    {
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Delivery(string streetAddress, string city, string state, string zipCode)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetAddress;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}