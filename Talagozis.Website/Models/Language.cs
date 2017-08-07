using System;

namespace Talagozis.Website.Models
{
    public class Language
    {
        public string name { get; set; }
        public string certification { get; set; }
        public LanguageProficiency proficiency { get; set; }
    }

    public enum LanguageProficiency
    {
        Native = 1,
        Elementary = 2,
        LimitedWorking = 3,
        ProfessionalWorking = 4,
        FullProfessionalWorking = 5,
    }
}
