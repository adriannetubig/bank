using bank_apiDomain.Dtos;
using bank_apiDomain.Entities;

namespace bank_apiRepository.Interfaces
{
    public interface ITransactionRepository
    {
        void Create(Transaction transaction);
        void Update(Transaction transaction);

        Transaction? RetrieveTransaction(Guid transactionGuid);
        IEnumerable<TransactionDto> RetrieveTransactions();
        Account? RetrieveAccount(string accountNumber);
        Customer? RetrieveCustomer(Guid customerGuid);
    }
}
