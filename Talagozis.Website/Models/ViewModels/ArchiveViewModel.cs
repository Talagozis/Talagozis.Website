using System;
using System.Collections.Generic;
using System.Linq;
using Talagozis.AspNetCore.Models.ViewModels;

namespace Talagozis.Website.Models.ViewModels
{
    public class ArchiveViewModel : ViewModel
    {
        public BlogArchive BlogArchive { get; set; }
        //public ICollection<Category> Categories { get; set; }
        //public ICollection<Tag> Tags { get; set; }
    }
}
