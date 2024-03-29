﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;

#nullable disable

namespace Talagozis.Website.Models.ViewModels
{
    public class PostViewModel : ViewModel
    {
        public CultureInfo cultureInfo { get; set; }
        public BlogPost BlogPost { get; set; }
        public BlogArchive blogArchive { get; set; }
        public PostArchive<BlogPost> PostArchive { get; set; }
        public IDictionary<CultureInfo, BlogPost> CultureRelatedBlogPosts { get; set; }
    }
}
