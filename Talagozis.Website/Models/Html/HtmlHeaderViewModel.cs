using System.Collections.Generic;

namespace Talagozis.Website.Models.Html
{
    public class HtmlHeaderViewModel
    {
        public string title { get; set; }
        public ICollection<Breadcrump> breadcrumps { get; set; }

        public HtmlHeaderViewModel()
        {
            this.breadcrumps = new List<Breadcrump>();
        }
    }

    public class Breadcrump
    {
        public string area { get; set; }
        public string controller { get; set; }
        public string action { get; set; }

        //public string routeName { get; set; }
        //public object routeValues { get; set; }
        //public string controller { get; set; }
        //public string action { get; set; }
        public string text { get; set; }
    }

}