using bank_apiService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bank_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class CustomersController : ControllerBase
    {
        private readonly ITransactionService _iTransactionService;

        public CustomersController(ITransactionService iTransactionService)
            => _iTransactionService = iTransactionService ?? throw new ArgumentNullException("ITransactionService Required");

        [HttpGet("")]
        public IActionResult Retrieve() => Ok(_iTransactionService.RetrieveCustomers());
    }
}
