using bank_apiDomain.Dtos;
using bank_apiDomain.Entities;

namespace bank_apiRepository.Interfaces
{
    interface ITransactionRepository
    {
        void Create(Transaction transaction);
        void Update(Transaction transaction);
        Transaction? RetrieveTransaction(Guid transactionGuid);
        IEnumerable<TransactionDto> RetrieveTransactions();
    }
}
