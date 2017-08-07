﻿using AnticevicApi.BL.Handlers.Car;
using AnticevicApi.Model.Binding.Car;
using AnticevicApi.Model.Constants.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using View = AnticevicApi.Model.View.Car;

namespace AnticevicApi.Controllers.Car
{
    [Authorize(Roles = UserRole.User)]
    [Route("[controller]")]
    public class CarController : BaseController<CarController>
    {
        private readonly ICarHandler _carHandler;

        public CarController(ILogger<CarController> logger, ICarHandler carHandler) : base(logger)
        {
            _carHandler = carHandler;
        }

        #region Get

        [HttpGet]
        [Route("")]
        public IEnumerable<View.Car> Get()
        {
            return _carHandler.Get();
        }

        [HttpGet]
        [Route("{id}/log/count")]
        public int GetLogCount(string id)
        {
            return _carHandler.GetLogCount(id);
        }

        [HttpGet]
        [Route("{id}/log/latest")]
        public View.CarLog GetLogLatest(string id)
        {
            return _carHandler.GetLatestLog(id);
        }

        #endregion

        #region Post

        [HttpPost]
        [HttpPut]
        [Route("{id}/log")]
        public DateTime PostLog([FromBody] CarLogBinding binding, string id)
        {
            binding.CarValueId = id;
            return _carHandler.CreateLog(binding);
        }

        #endregion

        #region Put

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutCar(string id, [FromBody] CarBinding car)
        {
            _carHandler.Create(id, car);

            return Ok();
        }

        #endregion
    }
}
