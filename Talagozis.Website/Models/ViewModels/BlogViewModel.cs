using System;
using System.Collections.Generic;
using System.Linq;
using Piranha.Data;

namespace Talagozis.Website.Models.ViewModels
{
    public class BlogViewModel : ViewModel
    {
        public ICollection<BlogArchive> Archives { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
