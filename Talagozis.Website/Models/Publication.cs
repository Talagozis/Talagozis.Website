using System;

namespace Talagozis.Website.Models
{
    public class Publication
    {
        public string title { get; set; }
        public string publisher { get; set; }
        public string[] authors { get; set; }
        public DateTime date { get; set; }
        public string publicationLink { get; set; }
        public string githubLink { get; set; }
        public string pdfLink { get; set; }
        public string description { get; set; }
    }
}
