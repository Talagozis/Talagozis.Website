using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Talagozis.Website.Models
{
    [PageType(Title = "HomePage")]
    [PageTypeRoute(Title = "Home", Route = "/home")]    
    public class HomePage  : Page<HomePage>
    {
    }
}