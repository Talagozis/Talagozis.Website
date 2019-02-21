using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talagozis.AspNetCore.Services.Paypal;
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
            var redirectLink = await paypalService.purchase(productBid == 1 ? 3.5m : 5m, "EUR");

            return Redirect(redirectLink);
        }

        public async Task<IActionResult> Success([FromServices]IPaypalService paypalService, string paymentId, string token, string PayerID)
        {
            try
            {
                await paypalService.approve(PayerID, paymentId);
                return Ok("Success!");
            }
            catch (Exception ex)
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
