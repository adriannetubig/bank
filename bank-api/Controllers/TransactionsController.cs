using bank_apiDomain.Dtos;
using bank_apiDomain.ValueObjects;
using bank_apiService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace bank_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class TransactionsController : ControllerBase
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
                return ErrorResult(createResult);
            else
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
        }

        [HttpPut("{transactionId}")]
        public IActionResult Update(Guid transactionId, TransactionDto transactionDto)
        {
            var updateResult = _iTransactionService.Update(transactionId, transactionDto);

            if (updateResult.IsFailure)
                return ErrorResult(updateResult);
            else
                return Ok();
        }

        private IActionResult ErrorResult(ValidationResult validationResult)
        {
            if (validationResult.IsNotFound)
                return NotFound(validationResult.Error);
            else if (validationResult.IsValidationError)
                return BadRequest(validationResult.Error);
            else if (validationResult.IsForbidden)
                return new ObjectResult(validationResult.Error)
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            else
                return BadRequest(validationResult.Error);
        }
    }
}
