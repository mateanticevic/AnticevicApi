﻿using AnticevicApi.BL.Handlers.Tracking;
using AnticevicApi.Model.Binding.Common;
using AnticevicApi.Model.Binding.Tracking;
using AnticevicApi.Utilities.Geo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using View = AnticevicApi.Model.View.Tracking;

namespace AnticevicApi.Controllers.Tracking
{
    [Route("[controller]")]
    public class TrackingController : BaseController<TrackingController>
    {
        private readonly ITrackingHandler _trackingHandler;

        public TrackingController(ILogger<TrackingController> logger, ITrackingHandler trackingHandler) : base(logger)
        {
            _trackingHandler = trackingHandler;
        }

        #region Get

        [HttpGet]
        public IEnumerable<View.Tracking> Get([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return _trackingHandler.Get(new FilteredBinding(from, to));
        }

        [HttpGet]
        [Route("gpx")]
        public string GetGpx([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return _trackingHandler.Get(new FilteredBinding(from, to))
                                  .ToGpx()
                                  .ToString();
        }

        [HttpGet]
        [Route("last")]
        public View.TrackingCurrent GetLast()
        {
            return _trackingHandler.GetLast();
        }

        [HttpGet]
        [Route("count")]
        public int GetCount([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return _trackingHandler.GetCount(new FilteredBinding(from, to));
        }

        [HttpGet]
        [Route("unique/count")]
        public int GetUniqueCount([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return _trackingHandler.GetUniqueCount(new FilteredBinding(from, to));
        }

        [HttpGet]
        [Route("distance")]
        public int GetDistance([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            return _trackingHandler.GetDistance(new FilteredBinding(from, to));
        }

        #endregion

        #region Put

        [HttpPut]
        public bool Put([FromBody] TrackingBinding binding)
        {
            return _trackingHandler.Create(binding);
        }

        [HttpPut]
        [Route("kml")]
        public bool PutKml([FromBody] string kmlRaw)
        {
            var kml = XDocument.Parse(kmlRaw);

            return _trackingHandler.ImportFromKml(kml);
        }

        #endregion
    }
}