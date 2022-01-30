namespace bank_apiDomain.Dtos
{
    public sealed class TransactionDto
    {
        public Guid? Id { get; init; }
        public string FromAccount { get; init; }
        public string ToAccount { get; init; }
        public string Description { get; init; }
        public decimal? Amount { get; init; }
        public DateTime? Date { get; init; }
        public CustomerDto Owner { get; init; }
    }
}
