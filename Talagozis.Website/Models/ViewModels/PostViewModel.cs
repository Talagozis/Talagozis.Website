using System;
using System.Collections.Generic;
using System.Linq;
using Piranha.Data;

namespace Talagozis.Website.Models.ViewModels
{
    public class PostViewModel : ViewModel
    {
        public BlogPost BlogPost { get; set; }
        public BlogArchive BlogArchive { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
