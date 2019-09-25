using System;
using System.Collections.Generic;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;

namespace Talagozis.Website.Models.ViewModels
{
    public class BlogViewModel : ViewModel
    {
        public ICollection<PostArchive<PostBase>> Archives { get; set; }
        public ICollection<Taxonomy> Categories { get; set; }
        public ICollection<TaxonomyList> Tags { get; set; }

    }
}
