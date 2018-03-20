using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public class WorkExperience
    {
        public string position { get; set; }
        public string companyName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public string typeOfBusiness { get; set; }
        public string link { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
