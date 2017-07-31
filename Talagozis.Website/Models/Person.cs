using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public class Person
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string fullName
        {
            get { return this.surname + " " + this.forename; }
        }
        public DateTime dob { get; set; }
        public string pob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string linkedinLink { get; set; }
        public string[] jobTitles { get; set; }
        public ICollection<Education> educations { get; set; }
        public ICollection<WorkingExperience> workingExperience { get; set; }
        public ICollection<Skill> skills { get; set; }
        public ICollection<Interest> interests { get; set; }
        public ICollection<Portfolio> portfolios { get; set; }
    }


}