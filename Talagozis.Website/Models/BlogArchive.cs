using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;

namespace Talagozis.Website.Models
{
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive  : ArchivePage<BlogArchive>
    {
        /// <summary>
        /// Gets/sets the heading.
        /// </summary>
        [Region]
        public Regions.Heading Heading { get; set; }

    }
}