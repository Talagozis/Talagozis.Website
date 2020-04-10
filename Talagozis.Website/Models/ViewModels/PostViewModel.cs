using System;
using System.Collections.Generic;
using System.Linq;
using Talagozis.AspNetCore.Models.ViewModels;

namespace Talagozis.Website.Models.ViewModels
{
    public class PostViewModel : ViewModel
    {
        public BlogPost BlogPost { get; set; }
        public BlogArchive BlogArchive { get; set; }
    }
}
