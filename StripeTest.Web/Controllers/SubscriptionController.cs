using Microsoft.AspNetCore.Mvc;
using StripeTest.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace StripeTest.Web.Controllers
{
    public class SubscriptionController : BaseController
    {
        private readonly IStripeSubscriptionService _stripeSubscriptionService;
        public SubscriptionController(IStripeSubscriptionService stripeSubscriptionService)
        {
            _stripeSubscriptionService = stripeSubscriptionService;
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]string days)
        {
            await _stripeSubscriptionService.CreateSubscription(days);
            return Ok();
        }
    }
}
