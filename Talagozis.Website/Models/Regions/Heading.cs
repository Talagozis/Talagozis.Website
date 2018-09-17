using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Talagozis.Website.Models.Regions
{
    public class Heading
    {
        [Field(Title = "Primary image")]
        public ImageField PrimaryImage { get; set; }

        [Field]
        public HtmlField Ingress { get; set; }

        [Field(Title = "Short description")]
        public HtmlField shortDescription { get; set; }
    }
}