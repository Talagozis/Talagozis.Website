using System;
using System.Collections.Generic;
using Piranha.Models;
using Talagozis.AspNetCore.Models.ViewModels;

namespace Talagozis.Website.Models.ViewModels
{
    public class BlogViewModel : ViewModel
    {
        public ICollection<BlogArchive> Archives { get; set; }

    }
}
