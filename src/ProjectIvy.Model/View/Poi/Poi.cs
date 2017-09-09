﻿using ProjectIvy.Extensions.BuiltInTypes;
using DatabaseModel = ProjectIvy.Model.Database.Main;

namespace ProjectIvy.Model.View.Poi
{
    public class Poi
    {
        public Poi(DatabaseModel.Travel.Poi x)
        {
            Category = x.PoiCategory.ConvertTo(y => new PoiCategory(y));
            Latitude = x.Latitude;
            Longitude = x.Longitude;
            Name = x.Name;
            Id = x.ValueId;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public PoiCategory Category { get; set; }
    }
}