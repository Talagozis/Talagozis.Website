using System;
using System.Collections.Generic;
using System.Linq;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;

namespace Talagozis.Website.Models.ViewModels
{
    public class PostViewModel : ViewModel
    {
        public BlogPost BlogPost { get; set; }
        public PostArchive<PostBase> PostArchive { get; set; }
        public ICollection<Taxonomy> Categories { get; set; }
        public ICollection<Taxonomy> Tags { get; set; }
    }
}
