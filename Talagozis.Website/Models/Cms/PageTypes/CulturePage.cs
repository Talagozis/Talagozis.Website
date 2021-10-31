using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

#nullable disable

namespace Talagozis.Website.Models.Cms.PageTypes
{
    [PageType(Title = "Culture page")]
    [ContentTypeRoute(Title = "Culture page", Route = "/home")]
    public class CulturePage : Page<CulturePage>
    {
        [Region(Title = "Culture", Display = RegionDisplayMode.Content)]
        public DataSelectField<CultureItem> Culture { get; set; }
    }
}