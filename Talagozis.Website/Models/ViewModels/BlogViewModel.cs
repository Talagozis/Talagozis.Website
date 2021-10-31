using System;
using System.Collections.Generic;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;

#nullable disable

namespace Talagozis.Website.Models.ViewModels
{
    public class BlogViewModel : ViewModel
    {
        //public ICollection<BlogPage> Archives { get; set; }
        public ICollection<PostArchive<BlogPost>> PostArchives { get; set; }
        public ICollection<BlogArchive> Archives { get; internal set; }
    }
}
