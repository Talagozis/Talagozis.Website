using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Talagozis.Website.App_Plugins.Services;
using Talagozis.Website.Models.Configurations;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class PaymentController : Controller
    {       
        [HttpGet]
        public IActionResult Index()
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();

            return View("~/Views/Payment/Payment.cshtml", paymentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase([FromServices]IOptions<PaypalCredentials> paypalCredentials, uint productBid)
        {
            PaypalService paypalService = new PaypalService(paypalCredentials.Value);
            var redirectLink = await paypalService.purchase(1m);

            return Redirect(redirectLink);
        }

        public async Task<IActionResult> Success([FromServices]IOptions<PaypalCredentials> paypalCredentials, string paymentId, string token, string PayerID)
        {
            PaypalService paypalService = new PaypalService(paypalCredentials.Value);

            try
            {
                await paypalService.approve(PayerID, paymentId);
                return Ok("Success!");
            }
            catch (Exception e)
            {
                return Ok("Failed!");
            }
        }

        public async Task<IActionResult> Canceled()
        {

            return Ok("Canceled!");
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
