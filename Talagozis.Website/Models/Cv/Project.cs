using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models.Cv
{
    public class Project
    {
        public string name { get; set; }
        public string typeOfBusiness { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public ICollection<IPerson> contributors { get; set; }
        public ICollection<Link> links { get; set; }
        public string githubLink { get; set; }
        public string description { get; set; }
        public ICollection<string> tags { get; set; }
    }
}
