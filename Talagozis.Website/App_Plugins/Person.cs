using System;

namespace Talagozis.Website.App_Plugins
{
    public class Person
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string pob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string facebookLink { get; set; }
        public string linkedinLink { get; set; }
        public string[] jobTitles { get; set; }
        public string fullName 
        {
            get { return this.surname + " " + this.forename; }
        }
    }


}