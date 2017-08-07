using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public class Patent
    {
        public string title { get; set; }
        public string office { get; set; }
        public string applicationNUmber { get; set; }
        public ICollection<IPerson> inventors { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }
}
