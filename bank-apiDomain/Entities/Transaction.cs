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
        private Transaction(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            TransactionGuid = transactionDto.Id.Value;
            Amount = transactionDto.Amount.Value;
            TransactionDate = transactionDto.Date.Value;
            Description = transactionDto.Description;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Customer = customer;
        }

        public static Result<Transaction> Create(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            var requiredFieldsResult = RequiredFields(transactionDto, fromAccount, toAccount, customer);
            if (requiredFieldsResult.IsFailure)
                return Result.Failure<Transaction>(requiredFieldsResult.Error);

            return Result.Success(new Transaction(transactionDto, fromAccount, toAccount, customer));
        }

        public Result Update(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            var requiredFieldsResult = RequiredFields(transactionDto, fromAccount, toAccount, customer);
            if (requiredFieldsResult.IsFailure)
                return Result.Failure(requiredFieldsResult.Error);

            TransactionGuid = transactionDto.Id.Value;
            Amount = transactionDto.Amount.Value;
            TransactionDate = transactionDto.Date.Value;
            Description = transactionDto.Description;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Customer = customer;

            return Result.Success();
        }

        private static Result RequiredFields(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            if (transactionDto == null)
                return Result.Failure("Transaction Required");
            if (transactionDto.Owner == null)
                return Result.Failure("Transaction Owner Required");
            if (!transactionDto.Id.HasValue)
                return Result.Failure("Transaction Id Required");
            if (!transactionDto.Amount.HasValue)
                return Result.Failure("Transaction Amount Required");
            if (!transactionDto.Date.HasValue)
                return Result.Failure("Transaction Date Required");
            if (string.IsNullOrEmpty(transactionDto.FromAccount))
                return Result.Failure("Transaction FromAccount Required");
            if (string.IsNullOrEmpty(transactionDto.ToAccount))
                return Result.Failure("Transaction ToAccount Required");
            if (string.IsNullOrEmpty(transactionDto.Description))
                return Result.Failure("Transaction Description Required");

            if (fromAccount == null)
                return Result.Failure("FromAccount does not exist");
            if (toAccount == null)
                return Result.Failure("ToAccount does not exist");
            if (customer == null)
                return Result.Failure("Customer does not exist");

            return Result.Success();
        }

    }
}
