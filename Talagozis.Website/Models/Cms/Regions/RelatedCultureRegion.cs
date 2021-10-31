using System;
using Piranha.Extend;
using Piranha.Extend.Fields;

#nullable disable

namespace Talagozis.Website.Models.Cms.Regions
{
    public class RelatedCultureRegion
    {
        [Field]
        public DataSelectField<CultureItem> Culture { get; set; }

        [Field]
        public PostField RelatedPost { get; set; }
    }
}