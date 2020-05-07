using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talagozis.Payments.Paypal.Abstractions;
using Talagozis.Payments.Paypal.Extensions;
using Talagozis.Payments.Paypal.SDK;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class PaymentController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();

            return View("~/Views/Payment/Payment.cshtml", paymentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase([FromServices]IPaypalService paypalService, uint productBid)
        {
            string returnUrl = "/payment/success";
            string cancelUrl = "/payment/canceled";

            //var redirectLink = await paypalService.purchase<PayPalCheckoutSdk.Orders.Order>(productBid == 1 ? 3.5m : 5m, Currency.EUR, returnUrl, cancelUrl); 
            Payment payment = await paypalService.paymentCreate(productBid == 1 ? 3.5m : 5m, Talagozis.Payments.Models.Currency.EUR, returnUrl, cancelUrl);

            return Redirect(payment.getRedirectionUrl());
        }

        public async Task<IActionResult> Success([FromServices]IPaypalService paypalService, string paymentId, string token, string PayerID)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(token))
                    await paypalService.ordersCapture(token);
                else if (!string.IsNullOrWhiteSpace(paymentId) && !string.IsNullOrWhiteSpace(PayerID))
                    await paypalService.paymentExecute(PayerID, paymentId);
                else
                    throw new Exception();


                return Ok("Success!");
            }
            catch (Exception)
            {
                return Ok("Failed!");
            }
        }

        public IActionResult Canceled()
        {

            return Ok("Canceled!");
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
