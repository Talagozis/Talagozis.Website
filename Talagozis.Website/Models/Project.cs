using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public class Project
    {
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public ICollection<IPerson> contributors { get; set; }
        public string link { get; set; }
        public string githubLink { get; set; }
        public string description { get; set; }
    }
}
