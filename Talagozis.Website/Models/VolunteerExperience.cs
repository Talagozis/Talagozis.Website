using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public class VolunteerExperience
    {
        public string organizationName { get; set; }
        public string position { get; set; }
        public VolunteerCause[] causes { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }

    public enum VolunteerCause
    {
        ArtsAndCulture = 1,
        AnimalRights = 2,
        Children = 3,
        CivilRights = 4,
        HumanitarianRelief = 5,
        EconomicEmpowerment = 6,
        Education = 7,
        Enviroment = 8,
        Health = 9,
        HumanRights = 10,
        Politics = 11,
        PovertyAlleviation = 12,
        ScienceAndTechnology = 13,
        SocialServices = 14,
    }
}