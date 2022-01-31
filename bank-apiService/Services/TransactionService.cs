using bank_apiDomain.Dtos;
using bank_apiDomain.Entities;
using bank_apiDomain.ValueObjects;
using bank_apiRepository.Interfaces;
using bank_apiService.Interfaces;

namespace bank_apiService.Services
{
    public sealed class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository) =>
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException("ITransactionRepository Required");

        public ValidationResult Create(TransactionDto transactionDto)
        {
            //ToDo: check if this will still work if fields are null
            var fromAccount = _transactionRepository.RetrieveAccount(transactionDto.FromAccount);
            var toAccount = _transactionRepository.RetrieveAccount(transactionDto.ToAccount);
            var customer = _transactionRepository.RetrieveCustomer(transactionDto.Owner.Id.Value);

            var createResult = Transaction.Create(transactionDto, fromAccount, toAccount, customer);

            if (createResult.IsSuccess)
                _transactionRepository.Create(createResult.Value);

            return createResult;
        }

        public ValidationResult Update(Guid transactionGuid, TransactionDto transactionDto) //ToDo: Handle missing transaction
        {
            //ToDo: check if this will still work if fields are null
            var fromAccount = _transactionRepository.RetrieveAccount(transactionDto.FromAccount);
            var toAccount = _transactionRepository.RetrieveAccount(transactionDto.ToAccount);
            var customer = _transactionRepository.RetrieveCustomer(transactionDto.Owner?.Id ?? Guid.Empty);
            var transaction = _transactionRepository.RetrieveTransaction(transactionGuid);

            var updateResult = transaction.Update(transactionDto, fromAccount, toAccount, customer);

            if (updateResult.IsSuccess)
                _transactionRepository.Update(transaction);

            return updateResult;
        }

        public IEnumerable<TransactionDto> RetrieveTransactions() => _transactionRepository.RetrieveTransactions();
    }
}
