using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace Talagozis.Website.Models
{
    [PageType(Title = "Blog page", UseBlocks = false, IsArchive = true)]
    public class BlogArchive  : Page<BlogArchive>
    {
        /// <summary>
        /// Gets/sets the heading.
        /// </summary>
        [Region]
        public Regions.Heading Heading { get; set; }

    }
}