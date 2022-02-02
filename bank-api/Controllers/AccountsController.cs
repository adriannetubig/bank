using bank_apiService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bank_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly ITransactionService _iTransactionService;

        public AccountsController(ITransactionService iTransactionService)
            => _iTransactionService = iTransactionService ?? throw new ArgumentNullException("ITransactionService Required");

        [HttpGet("{customerGuid}")]
        public IActionResult Retrieve(Guid customerGuid) => Ok(_iTransactionService.RetrieveAccountNumbers(customerGuid));

        [HttpGet("")]
        public IActionResult Retrieve() => Ok(_iTransactionService.RetrieveAccountNumbers());
    }
}
