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

                if (stripeEvent.Type.Contains("payment_intent"))
                {
                    var eventResult = stripeEvent.Data.Object as PaymentIntent;
                    _logger.LogInformation("Succeeded: {ID}", eventResult);
                }
                else if (stripeEvent.Type.Contains("expired"))
                {
                    var eventResult = Json(stripeEvent.Data.Object).Value;
                    _logger.LogInformation("Event contains EXPIRED: {ID}", eventResult);
                }
                else if (stripeEvent.Type.Contains("charge"))
                {
                    var eventResult = Json(stripeEvent.Data.Object).Value;
                    _logger.LogInformation("Event contains CHARGE: {ID}", eventResult);
                }
                else if (stripeEvent.Type.Contains("subscription"))
                {
                    var eventResult = Json(stripeEvent.Data.Object).Value;
                    _logger.LogInformation("Event contains SUBSCRIPTION: {ID}", eventResult);
                }
                else if (stripeEvent.Type == Events.PaymentMethodAttached)
                {
                    var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                    _logger.LogInformation("Payment Method Attached: {ID}", paymentMethod.Id);
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
