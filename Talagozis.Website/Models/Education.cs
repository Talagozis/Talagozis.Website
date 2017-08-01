using System;

namespace Talagozis.Website.Models
{
    public class Education
    {
        public string title { get; set; }
        public string university { get; set; }
        public int courseYears { get; set; }
        public DateTime graduationDate { get; set; }
        public string thesisTitle { get; set; }
        public string[] mainCourses { get; set; }
        public string description { get; set; }
    }
}
