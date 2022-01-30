using bank_apiDomain.ValueObjects;

namespace bank_apiDomain.Entities
{
    public class Customer : BaseEntity
    {
        public Guid CustomerGuid { get; private set; }
        public Name Name { get; private set; }

        protected Customer() { }
    }
}
