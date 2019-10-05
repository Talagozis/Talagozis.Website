using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace Talagozis.Website.Models
{
    [PostType(Title = "Blog post")]
    public class BlogPost : Post<BlogPost>
    {
        /// <summary>
        /// Gets/sets the heading.
        /// </summary>
        [Region]
        public Regions.Heading Heading { get; set; }
    }
}