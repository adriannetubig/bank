namespace bank_apiDomain.Entities
{
    public class Account : BaseEntity
    {
        public string AccountNumber { get; private set; }
        public Customer Customer { get; private set; }

        protected Account() { }
    }
}
