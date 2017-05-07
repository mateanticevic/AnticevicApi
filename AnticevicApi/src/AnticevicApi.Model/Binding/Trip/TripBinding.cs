﻿using System;

namespace AnticevicApi.Model.Binding.Trip
{
    public class TripBinding
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime TimestampEnd { get; set; }

        public DateTime TimestampStart { get; set; }
    }
}