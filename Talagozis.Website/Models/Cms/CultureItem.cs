using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Options;
using Piranha.Extend.Fields;
using Talagozis.AspNetCore.Localization;

namespace Talagozis.Website.Models.Cms
{
    public class CultureItem
    {
        private CultureItem(string id, CultureInfo cultureInfo) 
        {
            this.Id = id;
            this.cultureInfo = cultureInfo;
        }

        // The id of the page
        public string Id { get; private set; }

        // The model
        public CultureInfo cultureInfo { get; private set; }

        // Gets a single item with the provided id using the
        // injected services you specify.
        static CultureItem GetById(string id)
        {
            return new CultureItem(id, CultureInfo.GetCultureInfo(id));
        }

        // Gets all of the available items to choose from using
        // the injected services you specify.
        static IEnumerable<DataSelectFieldItem> GetList(IOptions<LanguageRouteConstraintOption> options)
        {
            return options.Value.getCultures().Select(c => new DataSelectFieldItem
            {
                Id = c.TwoLetterISOLanguageName,
                Name = $"{c.EnglishName} ({c.NativeName})"
            });
        }
    }

}