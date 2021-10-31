using System;
using System.Collections.Generic;

#nullable disable

namespace Talagozis.Website.Models.Cv
{
    public class Education
    {
        public string title { get; set; }
        public string university { get; set; }
        public int courseYears { get; set; }
        public DateTime? graduationDate { get; set; }
        public string thesisTitle { get; set; }
        public string description { get; set; }
        public ICollection<Course> mainCourses { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
