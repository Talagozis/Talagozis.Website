using System;
using System.Collections.Generic;
using System.Linq;

namespace Talagozis.Website.Models.ViewModels
{
    public class BlogViewModel : ViewModel
    {
        public ICollection<BlogArchive> Archives { get; set; }

    }
}
