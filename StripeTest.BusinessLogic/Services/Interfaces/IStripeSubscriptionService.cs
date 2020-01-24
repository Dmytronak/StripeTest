using System.Threading.Tasks;

namespace StripeTest.BusinessLogic.Services.Interfaces
{
    public interface IStripeSubscriptionService
    {
        Task CreateSubscription(string days);
    }
}
