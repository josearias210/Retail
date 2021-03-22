using Retail.Common.Entities;

namespace Retail.Core.Rule.Order
{
    public class DescriptionOrderProductIsRequired : IBusinessRule
    {
        private readonly string description;

        public DescriptionOrderProductIsRequired(string description)
        {
            this.description = description;
        }

        public string Message => "Description is required";


        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(description);
        }
    }
}
