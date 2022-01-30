using bank_apiRepository;
using bank_apiRepository.Interfaces;
using bank_apiRepository.Repositories;
using bank_apiService.Interfaces;
using bank_apiService.Services;

namespace bank_api.Helper
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddScoped(a => new BankApiContext(connectionString));

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
