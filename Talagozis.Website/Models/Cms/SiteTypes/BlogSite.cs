using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace Talagozis.Website.Models.Cms.SiteTypes
{
    [SiteType(Title = "Default site")]
    public class BlogSite : SiteContent<BlogSite>
    {
        [Region]
        public Regions.SiteInfo Information { get; set; }
    }
}