using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable

namespace Talagozis.Website.Models.Cv
{
    public class Person : IPerson
    {
        public string css { get; set; }
        public string avatarPicturePath { get; set; }

        public string forename { get; set; }
        public string surname { get; set; }
        public string fullName => (this.forename + " " + this.surname).Trim();
        public DateTime dob { get; set; }

        public string age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - this.dob.Year;
                if (this.dob.Date > today.AddYears(-age))
                    return (age - 1).ToString("##", CultureInfo.InvariantCulture);

                return age--.ToString("##", CultureInfo.InvariantCulture);
            }
        }

        public string pob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
		public string emailWeb => this.email.Replace("@", "[at]").Replace(".", "[dot]");
        public string website { get; set; }
        public string websiteBLog { get; set; }
        public Address Address { get; set; }
        public string phoneNumber { get; set; }
        public string nationality { get; set; }
        public string maritalStatus { get; set; }

        public string linkedinLink { get; set; }

        public string linkedinLabel => this.linkedinLink.Replace("https://www.linkedin.com", "")
                                                   .Replace("https://linkedin.com", "")
                                                   .TrimEnd('/');
        public string githubLink { get; set; }
        public string githubLabel => this.githubLink.Replace("https://github.com", "")
                                                 .TrimEnd('/');
        public string twitterLink { get; set; }
        public string twitterLabel => this.twitterLink;
        public ICollection<string> jobTitles { get; set; }
        public string description { get; set; }
        public ICollection<Education> educations { get; set; }
        public ICollection<WorkExperience> workExperience { get; set; }
        public ICollection<ResearchExperience> researchExperience { get; set; }
        
        public ICollection<CoreSkill> coreSkills { get; set; }
        
        public ICollection<SoftSkill> softSkills { get; set; }
        public ICollection<Interest> interests { get; set; }
        public ICollection<Portfolio> portfolios { get; set; }
        public ICollection<Awards> awards { get; set; }
        public ICollection<OpenSourceContribution> openSourceContributions { get; set; }
    }
}