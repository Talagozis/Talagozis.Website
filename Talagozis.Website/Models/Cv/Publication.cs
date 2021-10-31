using System;
using System.Collections.Generic;

#nullable disable

namespace Talagozis.Website.Models.Cv
{
    public class Publication
    {
        public string title { get; set; }
        public string publisher { get; set; }
        public ICollection<string> authors { get; set; }
        public DateTime date { get; set; }
        public string publicationLink { get; set; }
        public string githubLink { get; set; }
        public string pdfLink { get; set; }
        public string description { get; set; }
    }
}
