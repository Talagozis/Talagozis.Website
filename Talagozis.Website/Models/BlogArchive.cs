using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Talagozis.Website.Models
{
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive  : BlogPage<BlogArchive>
    {
    }
}