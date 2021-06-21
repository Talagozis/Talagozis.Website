using System;
using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using Talagozis.Website.Models.Cms.Regions;

namespace Talagozis.Website.Models.Cms.PostTypes
{
    [PostType(Title = "Blog post")]
    public class BlogPost : Post<BlogPost>
    {
        public new string MetaTitle => !string.IsNullOrWhiteSpace(base.MetaTitle) ? base.MetaTitle : this.Title;
        public new string MetaDescription => !string.IsNullOrWhiteSpace(base.MetaDescription) ? base.MetaDescription : this.Heading.Ingress.Value;
        public new string OgTitle => !string.IsNullOrWhiteSpace(base.OgTitle) ? base.OgTitle : this.Title;
        public new string OgDescription => !string.IsNullOrWhiteSpace(base.OgDescription) ? base.OgDescription : this.Heading.Ingress.Value;
        public new ImageField OgImage => base.OgImage ?? this.Heading.PrimaryImage;

        [Region(Title = "Heading", Icon = "fas fa-hard-hat")]
        public BlogPostHeadingRegion Heading { get; set; }

        [Region(Title = "Related Culture Post")]
        public IList<RelatedCultureRegion> RelatedCulturePost { get; set; }
    }

    public class BlogPostHeadingRegion
    {
        [Field(Title = "Primary image")]
        public ImageField PrimaryImage { get; set; }

        [Field(Title = "Ingress")]
        public HtmlField Ingress { get; set; }

        [Field(Title = "Subtitle")]
        public TextField SubTitle { get; set; }
    }

}