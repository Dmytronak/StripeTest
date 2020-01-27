using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using System.IO;
using System.Threading.Tasks;

namespace StripeTest.Web.Controllers
{

    public class WebHookController : BaseController
    {
        private readonly ILogger<WebHookController> _logger;
        private const string TEST_TYPES_SUBSCRIPTION = "customer.subscription";
        private const string TEST_TYPES_INVOICE = "invoice";

        public WebHookController(ILogger<WebHookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ListenStripeEvents()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);

                if (stripeEvent.Type.Contains(TEST_TYPES_SUBSCRIPTION))
                {
                    var eventResult = stripeEvent.Data.Object as Subscription;
                    _logger.LogInformation("Subscription event: {0}, Type: {1} Status: {2}", stripeEvent.Id, stripeEvent.Type, eventResult.Status);
                }
                else if (stripeEvent.Type.Contains(TEST_TYPES_INVOICE))
                {
                    var eventResult = stripeEvent.Data.Object as Invoice;
                    _logger.LogInformation("Invoice event: {0}, Type: {1} Status: {2}", stripeEvent.Id, stripeEvent.Type, eventResult.Status);
                }
                else
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
          
        }
    }
}
