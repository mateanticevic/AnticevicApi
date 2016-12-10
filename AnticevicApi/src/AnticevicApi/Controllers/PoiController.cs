﻿using AnticevicApi.BL.Handlers.Poi;
using AnticevicApi.Config;
using AnticevicApi.Model.View.Poi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace AnticevicApi.Controllers
{
    [Route("[controller]")]
    public class PoiController : BaseController
    {
        public PoiController(IOptions<AppSettings> options, IPoiHandler poiHandler) : base(options)
        {
            PoiHandler = poiHandler;
        }

        #region Get

        [HttpGet]
        [Route("categories")]
        public IEnumerable<PoiCategory> GetCategories()
        {
            return PoiHandler.GetCategories();
        }

        [HttpGet]
        [Route("lists")]
        public IEnumerable<PoiList> GetLists()
        {
            return PoiHandler.GetLists();
        }

        [HttpGet]
        [Route("list/{listValueId}/pois")]
        public IEnumerable<Poi> GetPois(string listValueId)
        {
            return PoiHandler.GetByList(listValueId);
        }

        #endregion
    }
}
