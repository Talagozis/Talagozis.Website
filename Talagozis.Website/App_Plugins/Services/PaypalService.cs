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
            var environment = new SandboxEnvironment(this.paypalCredentials.ClientId, this.paypalCredentials.ClientSecret);
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
                    CancelUrl = "http://localhost:55694/Payment/Canceled",
                    ReturnUrl = "http://localhost:55694/Payment/Success"
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

    }
}
