using bank_apiDomain.Dtos;
using bank_apiDomain.ValueObjects;

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

        public static ValidationResult<Transaction> Create(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            var requiredFieldsResult = RequiredFields(transactionDto, fromAccount, toAccount, customer);
            if (requiredFieldsResult.IsFailure)
                return ValidationResult<Transaction>.Failure(requiredFieldsResult);

            return ValidationResult<Transaction>.Success(new Transaction(transactionDto, fromAccount, toAccount, customer));
        }

        public ValidationResult Update(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            var requiredFieldsResult = RequiredFields(transactionDto, fromAccount, toAccount, customer);
            if (requiredFieldsResult.IsFailure)
                return ValidationResult.Failure(requiredFieldsResult);

            TransactionGuid = transactionDto.Id.Value;
            Amount = transactionDto.Amount.Value;
            TransactionDate = transactionDto.Date.Value;
            Description = transactionDto.Description;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Customer = customer;

            return ValidationResult.Success();
        }

        private static ValidationResult RequiredFields(TransactionDto transactionDto, Account fromAccount, Account toAccount, Customer customer)
        {
            if (transactionDto == null)
                return ValidationResult.Failure("Transaction Required");
            if (transactionDto.Owner == null)
                return ValidationResult.Failure("Transaction Owner Required");
            if (!transactionDto.Id.HasValue)
                return ValidationResult.Failure("Transaction Id Required");
            if (!transactionDto.Amount.HasValue)
                return ValidationResult.Failure("Transaction Amount Required");
            if (!transactionDto.Date.HasValue)
                return ValidationResult.Failure("Transaction Date Required");
            if (string.IsNullOrEmpty(transactionDto.FromAccount))
                return ValidationResult.Failure("Transaction FromAccount Required");
            if (string.IsNullOrEmpty(transactionDto.ToAccount))
                return ValidationResult.Failure("Transaction ToAccount Required");
            if (string.IsNullOrEmpty(transactionDto.Description))
                return ValidationResult.Failure("Transaction Description Required");
            if (!transactionDto.Owner.Id.HasValue)
                return ValidationResult.Failure("Transaction Owner Id Required");

            if (fromAccount == null)
                return ValidationResult.Failure("FromAccount does not exist", ErrorTypes.NotFound);
            if (toAccount == null)
                return ValidationResult.Failure("ToAccount does not exist", ErrorTypes.NotFound);
            if (customer == null)
                return ValidationResult.Failure("Customer does not exist", ErrorTypes.NotFound);

            if (fromAccount.Customer != customer)
                return ValidationResult.Failure("Customer do not own the account", ErrorTypes.Forbidden);

            return ValidationResult.Success();
        }

    }
}
