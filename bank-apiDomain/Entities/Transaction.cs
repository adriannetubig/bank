using bank_apiDomain.Dtos;
using CSharpFunctionalExtensions;

namespace bank_apiDomain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid TransactionGuid { get; private set; }
        public Account FromAccount { get; private set; }
        public Account ToAccount { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public Customer Customer { get; private set; }
        public string Description { get; private set; }

        protected Transaction() { }
        private Transaction(CreateTransactionDto createTransactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            TransactionGuid = createTransactionDto.Id.Value;
            Amount = createTransactionDto.Amount.Value;
            TransactionDate = createTransactionDto.Date.Value;
            Description = createTransactionDto.Description;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Customer = customer;
        }

        public static Result<Transaction> Create(CreateTransactionDto createTransactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            if (createTransactionDto == null)
                return Result.Failure<Transaction>("Transaction Required");
            if (createTransactionDto.Owner == null)
                return Result.Failure<Transaction>("Transaction Owner Required");
            if (!createTransactionDto.Id.HasValue)
                return Result.Failure<Transaction>("Transaction Id Required");
            if (!createTransactionDto.Amount.HasValue)
                return Result.Failure<Transaction>("Transaction Amount Required");
            if (!createTransactionDto.Date.HasValue)
                return Result.Failure<Transaction>("Transaction Date Required");
            if (string.IsNullOrEmpty(createTransactionDto.FromAccount))
                return Result.Failure<Transaction>("Transaction FromAccount Required");
            if (string.IsNullOrEmpty(createTransactionDto.ToAccount))
                return Result.Failure<Transaction>("Transaction ToAccount Required");
            if (string.IsNullOrEmpty(createTransactionDto.Description))
                return Result.Failure<Transaction>("Transaction Description Required");

            if (fromAccount == null)
                return Result.Failure<Transaction>("FromAccount does not exist");
            if (toAccount == null)
                return Result.Failure<Transaction>("ToAccount does not exist");
            if (customer == null)
                return Result.Failure<Transaction>("Customer does not exist");


            return Result.Success(new Transaction(createTransactionDto, fromAccount, toAccount, customer));
        }

    }
}
