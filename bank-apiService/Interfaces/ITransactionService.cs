using bank_apiDomain.Dtos;
using CSharpFunctionalExtensions;

namespace bank_apiService.Interfaces
{
    public interface ITransactionService
    {
        Result Create(TransactionDto transactionDto);
        Result Update(Guid transactionGuid, TransactionDto transactionDto);
        IEnumerable<TransactionDto> RetrieveTransactions();
    }
}
