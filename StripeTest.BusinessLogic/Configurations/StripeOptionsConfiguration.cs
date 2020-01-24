using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using StripeTest.BusinessLogic.Options;

namespace StripeTest.BusinessLogic.Configurations
{
    public static class StripeOptionsConfiguration
    {
        public static void AddStripeOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            StripeOption key = configuration.GetSection("Stripe").Get<StripeOption>();
            StripeConfiguration.SetApiKey(key.SecretKey);

        }
    }
}
