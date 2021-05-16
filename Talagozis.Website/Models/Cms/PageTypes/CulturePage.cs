using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using Talagozis.Website.Models.Cms.PostTypes;

namespace Talagozis.Website.Models.Cms.PageTypes
{
    [PageType(Title = "Culture page")]
    [ContentTypeRoute(Title = "Culture page")]
    public class CulturePage : Page<CulturePage>
    {
        [Region(Title = "Culture", Display = RegionDisplayMode.Content)]
        public DataSelectField<CultureItem> Culture { get; set; }
    }
}