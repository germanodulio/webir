using Common.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.DependencyInjection
{
    public static class ServiceLoader
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            // Add repositories dependency injection
            ConfigureServices(services, config);

            // Services
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
        }
    }
}
