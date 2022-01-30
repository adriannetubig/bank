using bank_apiDomain.Dtos;
using bank_apiDomain.Entities;
using bank_apiRepository.Interfaces;

namespace bank_apiRepository.Repositories
{
    public sealed class TransactionRepository: ITransactionRepository
    {
        private readonly BankApiContext _bankApiContext;

        public TransactionRepository(BankApiContext bankApiContext) => _bankApiContext = bankApiContext ?? throw new ArgumentNullException("BankApiContext Required");

        public void Create(Transaction transaction) => _bankApiContext.Transactions.Add(transaction);
        public void Update(Transaction transaction) => _bankApiContext.Transactions.Update(transaction);

        public Transaction? RetrieveTransaction(Guid transactionGuid) => _bankApiContext.Transactions.FirstOrDefault(a => a.TransactionGuid == transactionGuid);
        public IEnumerable<TransactionDto> RetrieveTransactions()
        {
            return _bankApiContext
                .Transactions
                .Select(a =>
                new TransactionDto
                {
                    Amount = a.Amount,
                    FromAccount = a.FromAccount.AccountNumber,
                    ToAccount = a.ToAccount.AccountNumber,
                    Date = a.TransactionDate,
                    Description = a.Description,
                    Id = a.TransactionGuid,
                    Owner = new CustomerDto
                    {
                        Id = a.Customer.CustomerGuid,
                        Name = a.Customer.Name.FullName()//ToDo: Check if this will work
                    }
                });
        }
    }
}
