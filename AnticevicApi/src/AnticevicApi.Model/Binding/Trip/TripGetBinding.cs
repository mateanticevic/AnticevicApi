﻿using AnticevicApi.Model.Binding.Common;

namespace AnticevicApi.Model.Binding.Trip
{
    public class TripGetBinding : FilteredPagedBinding
    {
        public string CityId { get; set; }
    }
}