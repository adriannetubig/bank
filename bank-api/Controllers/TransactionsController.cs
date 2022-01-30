using bank_apiDomain.Dtos;
using bank_apiService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace bank_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _iTransactionService;

        public TransactionsController(ITransactionService iTransactionService)
            => _iTransactionService = iTransactionService ?? throw new ArgumentNullException("ITransactionService Required");

        [HttpGet("")]
        public IActionResult Retrieve() => Ok(_iTransactionService.RetrieveTransactions());

        [HttpPost]
        public IActionResult Create(TransactionDto transactionDto)
        {
            var createResult = _iTransactionService.Create(transactionDto);
            if (createResult.IsFailure)
                return BadRequest(createResult.Error);
            else
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
        }

        [HttpPut("{transactionId}")]
        public IActionResult Update(Guid transactionId, TransactionDto transactionDto)
        {
            var createResult = _iTransactionService.Update(transactionId, transactionDto);
            if (createResult.IsFailure)
                return BadRequest(createResult.Error);
            else
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
        }
    }
}
