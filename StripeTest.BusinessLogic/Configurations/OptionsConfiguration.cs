using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StripeTest.BusinessLogic.Options;

namespace StripeTest.BusinessLogic.Configurations
{
    public static class OptionsConfiguration
    {
        public static void AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services
                .Configure<StripeOption>(configuration.GetSection("Stripe"));

        }
    }
}
