using System;

namespace Talagozis.Website.Models
{
    public class ResearchExperience
    {
        public string title { get; set; }
        public string organizationName { get; set; }
        public string tutorName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }
}
