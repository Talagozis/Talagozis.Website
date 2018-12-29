using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BraintreeHttp;
using PayPal.Core;
using PayPal.v1.Payments;
using Talagozis.Website.Models.Configurations;

namespace Talagozis.Website.App_Plugins.Services
{
    public class PaypalService
    {
        private readonly PaypalCredentials paypalCredentials;

        public PaypalService(PaypalCredentials paypalCredentials)
        {
            this.paypalCredentials = paypalCredentials;
        }

        public async Task<string> purchase(decimal price, string currency = "EUR")
        {
#if DEBUG
            var environment = new SandboxEnvironment(this.paypalCredentials.ClientId, this.paypalCredentials.ClientSecret);
#else
            var environment = new LiveEnvironment(this.paypalCredentials.ClientId, this.paypalCredentials.ClientSecret);
#endif
            var client = new PayPalHttpClient(environment);

            var payment = new Payment
            {
                Intent = "sale",
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Amount = new Amount
                        {
                            Total = price.ToString("N2", CultureInfo.InvariantCulture),
                            Currency = currency,
                        }
                    }
                },
                RedirectUrls = new RedirectUrls
                {
                    CancelUrl = this.paypalCredentials.RedirectUrlsDomain + @"/Payment/Canceled",
                    ReturnUrl = this.paypalCredentials.RedirectUrlsDomain + @"/Payment/Success"
                },
                Payer = new Payer
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                
                return result.Links.Single(a => a.Rel == "approval_url").Href;
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                throw;
            }

        }

        public async Task approve(string PayerID, string PaymentID)
        {
#if DEBUG
            var environment = new SandboxEnvironment(this.paypalCredentials.ClientId, this.paypalCredentials.ClientSecret);
#else
            var environment = new LiveEnvironment(this.paypalCredentials.ClientId, this.paypalCredentials.ClientSecret);
#endif
            var client = new PayPalHttpClient(environment);

            var paypalExecuteRequest = new PaymentExecuteRequest(PaymentID);
            paypalExecuteRequest.RequestBody(new PaymentExecution()
            {
                PayerId = PayerID
            });

            var res = await client.Execute(paypalExecuteRequest);
            var payment = res.Result<Payment>();
            if (payment.State != "approved")
            {
                throw new Exception(payment.FailureReason);
            }
        }

    }
}
