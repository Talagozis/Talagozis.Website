using System;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Talagozis.Website.Models.Cms.PageTypes
{
    [PageType(Title = "Standard page")]
    [PageTypeRoute(Title = "Default", Route = "/page")]
    public class StandardPage  : Page<StandardPage>
    {
    }
}