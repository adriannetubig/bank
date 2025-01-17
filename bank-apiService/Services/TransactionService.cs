﻿using bank_apiDomain.Dtos;
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
            var transactionGuid = transactionDto.Owner?.Id ?? Guid.Empty;

            if (_transactionRepository.TransactionExists(transactionGuid))
                return ValidationResult.Failure("Transaction already exists");

            var fromAccount = _transactionRepository.RetrieveAccount(transactionDto.FromAccount);
            var toAccount = _transactionRepository.RetrieveAccount(transactionDto.ToAccount);
            var customer = _transactionRepository.RetrieveCustomer(transactionGuid);

            var createResult = Transaction.Create(transactionDto, fromAccount, toAccount, customer);

            if (createResult.IsSuccess)
                _transactionRepository.Create(createResult.Value);

            return createResult;
        }

        public ValidationResult Update(Guid transactionGuid, TransactionDto transactionDto)
        {
            var transaction = _transactionRepository.RetrieveTransaction(transactionGuid);
            if (transaction == null)
                return ValidationResult.Failure("Transaction does not exist", ErrorTypes.NotFound);

            var fromAccount = _transactionRepository.RetrieveAccount(transactionDto.FromAccount);
            var toAccount = _transactionRepository.RetrieveAccount(transactionDto.ToAccount);
            var customer = _transactionRepository.RetrieveCustomer(transactionDto.Owner?.Id ?? Guid.Empty);

            var updateResult = transaction.Update(transactionDto, fromAccount, toAccount, customer);

            if (updateResult.IsSuccess)
                _transactionRepository.Update(transaction);

            return updateResult;
        }

        public IEnumerable<TransactionDto> RetrieveTransactions() => _transactionRepository.RetrieveTransactions();
        public IEnumerable<CustomerDto> RetrieveCustomers() => _transactionRepository.RetrieveCustomers();
        public IEnumerable<string> RetrieveAccountNumbers() => _transactionRepository.RetrieveAccountNumbers();
        public IEnumerable<string> RetrieveAccountNumbers(Guid customerGuid) => _transactionRepository.RetrieveAccountNumbers(customerGuid);
    }
}
