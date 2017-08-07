using System;

namespace Talagozis.Website.Models
{
    public class Certification
    {
        public string title { get; set; }
        public string authority { get; set; }
        public string licenseNumber { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string certificationLink { get; set; }
        public bool canExpire { get; set; }
        public string description { get; set; }
    }
}
