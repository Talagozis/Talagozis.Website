using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Talagozis.Website.Models.Cms.PageTypes
{
    [PageType(Title = "Blog archive", UseBlocks = false, IsArchive = true)]
    [ContentTypeRoute(Title = "Default", Route = "/archive")]
    public class BlogArchive  : Page<BlogArchive>
    {
        public new string MetaTitle => !string.IsNullOrWhiteSpace(base.MetaTitle) ? base.MetaTitle : this.Title;
        public new string MetaDescription => !string.IsNullOrWhiteSpace(base.MetaDescription) ? base.MetaDescription : this.Heading.Ingress.Value;
        public new string OgTitle => !string.IsNullOrWhiteSpace(base.OgTitle) ? base.OgTitle : this.Title;
        public new string OgDescription => !string.IsNullOrWhiteSpace(base.OgDescription) ? base.OgDescription : this.Heading.Ingress.Value;
        public new ImageField OgImage => base.OgImage ?? this.Heading.PrimaryImage;

        [Region(Title = "Heading", Icon = "fas fa-hard-hat")]
        public BlogArchiveHeadingRegion Heading { get; set; }

        [Region(Title = "Posts fallback", Icon = "fas fa-undo")]
        public PostFallbackRegion PostFallback { get; set; }
    }

    public class BlogArchiveHeadingRegion
    {
        [Field(Title = "Primary image")]
        public ImageField PrimaryImage { get; set; }

        [Field(Title = "Cover image")]
        public ImageField CoverImage { get; set; }

        [Field(Title = "Ingress")]
        public HtmlField Ingress { get; set; }

        [Field(Title = "Subtitle")]
        public TextField SubTitle { get; set; }
    }

    public class PostFallbackRegion
    {
        [Field(Title = "Primary image")]
        public ImageField PrimaryImage { get; set; }

        [Field(Title = "Cover image")]
        public ImageField CoverImage { get; set; }
    }



}