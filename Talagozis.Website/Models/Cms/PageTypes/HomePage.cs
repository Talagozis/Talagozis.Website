using System;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Talagozis.Website.Models.Cms.PageTypes
{
    [PageType(Title = "HomePage")]
    [PageTypeRoute(Title = "Home", Route = "/home")]    
    public class HomePage  : Page<HomePage>
    {
    }
}