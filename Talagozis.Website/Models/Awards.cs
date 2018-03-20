using System;

namespace Talagozis.Website.Models
{
    public class Awards
    {
        public string title { get; set; }
        public string issuer { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }
}
