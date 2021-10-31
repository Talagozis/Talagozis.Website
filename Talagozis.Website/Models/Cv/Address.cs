using System;

#nullable disable

namespace Talagozis.Website.Models.Cv
{
    public class Address
    {
        public string line { get; set; }
		public string region { get; set; }
        public string municipality { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
	}
}
