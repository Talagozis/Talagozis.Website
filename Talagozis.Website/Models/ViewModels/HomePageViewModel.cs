using System;
using System.Collections.Generic;
using System.Linq;
using Talagozis.AspNetCore.Models.ViewModels;
using Talagozis.Website.Models.Cv;

namespace Talagozis.Website.Models.ViewModels
{
    public class HomePageViewModel : ViewModel
    {
        public Person Person { get; set; }
        public ICollection<BlogPost> LatestPosts { get; set; }
        public ICollection<BlogArchive> Archives { get; set; }
    }
}
