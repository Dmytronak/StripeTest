using Microsoft.Extensions.DependencyInjection;
using StripeTest.BusinessLogic.Services;
using StripeTest.BusinessLogic.Services.Interfaces;

namespace StripeTest.BusinessLogic.Configurations
{
    public static class DependencyConfiguration
    {
        public static void AddDependencyConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IStripeSubscriptionService, StripeSubscriptionService>();
        }
    }
}
