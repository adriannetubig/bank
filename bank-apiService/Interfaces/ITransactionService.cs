using bank_apiDomain.Dtos;
using bank_apiDomain.ValueObjects;

namespace bank_apiService.Interfaces
{
    public interface ITransactionService
    {
        ValidationResult Create(TransactionDto transactionDto);
        ValidationResult Update(Guid transactionGuid, TransactionDto transactionDto);
        IEnumerable<TransactionDto> RetrieveTransactions();
        IEnumerable<CustomerDto> RetrieveCustomers();
        IEnumerable<string> RetrieveAccountNumbers();
        IEnumerable<string> RetrieveAccountNumbers(Guid customerGuid);
    }
}
