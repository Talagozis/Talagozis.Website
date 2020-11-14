using System;
using System.Collections.Generic;
using System.Linq;

namespace Talagozis.Website.Models.Cv
{
    public class WorkExperience
    {
        public string position { get; set; }
        public string companyName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public string typeOfBusiness { get; set; }
        public ICollection<Link> links { get; set; }
        public ICollection<Project> projects { get; set; }
        public ICollection<string> tags => this.projects?.Where(a => a.tags != null).SelectMany(a => a.tags)?.Distinct()?.ToList() ?? new List<string>();
    }
}
