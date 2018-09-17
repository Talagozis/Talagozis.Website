using System;

namespace Talagozis.Website.Models.Cv
{
    public class Organization
    {
        public string name { get; set; }
        public string position { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
    }
}
