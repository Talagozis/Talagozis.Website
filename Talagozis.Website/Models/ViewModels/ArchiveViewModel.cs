﻿using System;
using System.Collections.Generic;
using System.Linq;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;

#nullable disable

namespace Talagozis.Website.Models.ViewModels
{
    public class ArchiveViewModel : ViewModel
    {
        public BlogArchive blogArchive { get; set; }
        public PostArchive<BlogPost> PostArchive { get; set; }
        //public ICollection<Category> Categories { get; set; }
        //public ICollection<Tag> Tags { get; set; }
    }
}
