﻿using AnticevicApi.Model.Binding.Common;

namespace AnticevicApi.Model.Binding.Airport
{
    public class AirportGetBinding : PagedBinding
    {
        public bool? Visited { get; set; }

        public string CityId { get; set; }

        public string Countryid { get; set; }
    }
}
