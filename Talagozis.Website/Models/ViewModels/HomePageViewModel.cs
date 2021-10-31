using System;
using System.Collections.Generic;
using System.Linq;
using Talagozis.AspNetCore.Models.ViewModels;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
using Talagozis.Website.Models.Cv;

#nullable disable

namespace Talagozis.Website.Models.ViewModels
{
    public class HomePageViewModel : ViewModel
    {
        public Person Person { get; set; }
        public ICollection<BlogPost> LatestPosts { get; set; }
        public ICollection<BlogArchive> Archives { get; set; }
    }
}
