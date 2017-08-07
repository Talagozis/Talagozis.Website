using System;
using System.Collections.Generic;

namespace Talagozis.Website.Models
{
    public interface IPerson
    {
        string forename { get; set; }
        string surname { get; set; }
        DateTime dob { get; set; }
        string email { get; set; }
        string linkedinLink { get; set; }
        string githubLink { get; set; }
    }


}