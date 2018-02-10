﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectIvy.BL.Handlers.Consumation;
using ProjectIvy.Model.Binding.Consumation;

namespace ProjectIvy.Api.Controllers.Consumation
{
    [Route("[controller]")]
    public class ConsumationController : BaseController<ConsumationController>
    {
        private readonly IConsumationHandler _consumationHandler;

        public ConsumationController(ILogger<ConsumationController> logger, IConsumationHandler consumationHandler) : base(logger)
        {
            _consumationHandler = consumationHandler;
        }

        [HttpGet("Count")]
        public int Count(ConsumationGetBinding binding) => _consumationHandler.Count(binding);

        [HttpGet("Sum")]
        public int VolumeSum(ConsumationGetBinding binding) => _consumationHandler.VolumeSum(binding);
    }
}