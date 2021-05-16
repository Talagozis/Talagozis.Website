using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Piranha.Extend.Fields;

namespace Talagozis.Website.Models.Cms
{
    public class CultureItem
    {
        // The id of the page
        public string Id { get; set; }

        // The model
        public CultureInfo cultureInfo { get; set; }

        // Gets a single item with the provided id using the
        // injected services you specify.
        static CultureItem GetById(string id)
        {
            return new CultureItem
            {
                Id = id,
                cultureInfo = CultureInfo.GetCultureInfo(id)
            };
        }

        // Gets all of the available items to choose from using
        // the injected services you specify.
        static IEnumerable<DataSelectFieldItem> GetList()
        {
            return CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(c => new DataSelectFieldItem
            {
                Id = c.TwoLetterISOLanguageName,
                Name = $"{c.EnglishName} ({c.NativeName})"
            });
        }
    }

}