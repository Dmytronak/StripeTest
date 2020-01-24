using Microsoft.Extensions.Options;
using Stripe;
using StripeTest.BusinessLogic.Options;
using StripeTest.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StripeTest.BusinessLogic.Services
{
    public class StripeSubscriptionService : IStripeSubscriptionService
    {
        private const string TEST_PLAN =  "plan_GbZvoCPeZLUShk";
        private const string TEST_PLAN2 = "plan_Gbb646qs5FPoVM";
        private const string TEST_PLAN3 = "plan_GbbG98me25ouUo";
        private const string TEST_CUSTOMER = "cus_GbjMBVZNAqRGgc";
        private readonly StripeOption _stripeOptions;
        public StripeSubscriptionService(IOptions<StripeOption> stripeOptions)
        {
            _stripeOptions = stripeOptions.Value;
        }

        public async Task CreateSubscription(string days)
        {
            var testPlan = TEST_PLAN;

            if (days == "Two")
            {
                testPlan = TEST_PLAN2;

            }
            if (days == "Two")
            {
                testPlan = TEST_PLAN3;

            }
            StripeConfiguration.ApiKey = _stripeOptions.SecretKey;

            var options = new SubscriptionCreateOptions
            {
                Customer = TEST_CUSTOMER,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Plan = testPlan,
                    },
                },
            };
            var service = new SubscriptionService();
            Subscription subscription = service.Create(options);
        }
    }
}
