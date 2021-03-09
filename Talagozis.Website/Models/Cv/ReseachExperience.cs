using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models.Cv
{
    public class ResearchExperience
    {
        public string title { get; set; }
        public string organizationName { get; set; }
        public ICollection<string> tutorNames { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string publicationLink { get; set; }
    }
}
