using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Talagozis.Website.Models.Cv
{
    public class OpenSourceContribution
    {
        public enum Source
        {
            GitHub
        }

        public Source source { get; set; }
        public string name { get; set; }
        public string repository { get; set; }
        public string description { get; set; }
        public Link link { get; set; }
    }
}
