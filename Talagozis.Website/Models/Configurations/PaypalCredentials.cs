using System;

#nullable disable

namespace Talagozis.Website.Models.Configurations
{
    public class PaypalCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrlsDomain { get; set; }
    }
}
