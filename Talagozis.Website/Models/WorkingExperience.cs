using System;

namespace Talagozis.Website.Models
{
    public class WorkingExperience
    {
        public string title { get; set; }
        public string companyName { get; set; }
        public string project { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
    }
}
