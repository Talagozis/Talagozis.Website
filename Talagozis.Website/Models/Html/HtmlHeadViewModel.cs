namespace Talagozis.Website.Models.Html
{
    public class HtmlHeadViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string keywords { get; set; }

        public string canonical { get; set; }

        public string prefetchLink { get; set; }
        public string prerenderLink { get; set; }

        public string ogTitle { get; set; }
        public OgType? ogType { get; set; }
        public string ogImage { get; set; }
        public string ogUrl { get; set; }

        public string ogDescription { get; set; }
        public OgDeterminer? ogDeterminer { get; set; }
        public string ogLocale { get; set; }
        public string ogSiteName { get; set; }

        public string fbRestaurantRestaurant { get; set; }
        public string fbRestaurantContactInfoStreetAddress { get; set; }
        public string fbRestaurantContactInfoLocality { get; set; }
        public string fbRestaurantContactInfoRegion { get; set; }
        public string fbRestaurantContactInfoPostalCode { get; set; }
        public string fbRestaurantContactInfoCountryName { get; set; }
        public string fbRestaurantContactInfoEmail { get; set; }
        public string fbRestaurantContactInfoPhoneNumber { get; set; }
        public string fbRestaurantContactInfoWebsite { get; set; }
        public string fbPlaceLocationLatitude { get; set; }
        public string fbPlaceLocationLongitude { get; set; }
    }

    public enum OgType
    {
        Website,
        RestaurantMenu,
        RestaurantRestaurant
    }

    public static class OgTypeExtensions
    {
        public static string toString(this OgType me)
        {
            switch (me)
            {
                case OgType.Website:
                    return "website";
                case OgType.RestaurantMenu:
                    return "restaurant.menu";
                case OgType.RestaurantRestaurant:
                    return "restaurant.restaurant";
                default:
                    return "";
            }
        }
    }

    public enum OgDeterminer
    {
        A,
        An,
        The,
        Empty,
        Auto
    }

    public static class OgDeterminerExtensions
    {
        public static string toString(this OgDeterminer me)
        {
            switch (me)
            {
                case OgDeterminer.A:
                    return "a";
                case OgDeterminer.An:
                    return "an";
                case OgDeterminer.The:
                    return "the";
                case OgDeterminer.Empty:
                    return "";
                case OgDeterminer.Auto:
                    return "auto";
                default:
                    return "";
            }
        }
    }

}