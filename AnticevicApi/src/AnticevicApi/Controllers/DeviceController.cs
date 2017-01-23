﻿using AnticevicApi.BL.Exceptions;
using AnticevicApi.BL.Handlers.Device;
using AnticevicApi.Model.Binding.Device;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnticevicApi.Controllers
{
    [Route("[controller]")]
    public class DeviceController : BaseController<DeviceController>
    {
        private readonly IDeviceHandler _deviceHandler;

        public DeviceController(ILogger<DeviceController> logger, IDeviceHandler deviceHandler) : base(logger)
        {
            _deviceHandler = deviceHandler;
        }

        [HttpPut]
        [Route("{deviceId}/browserLog")]
        public StatusCodeResult PutBrowserLog([FromBody] BrowserLogBinding binding, string deviceId)
        {
            try
            {
                binding.DeviceId = deviceId;
                _deviceHandler.CreateBrowserLog(binding);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (ResourceExistsException e)
            {
                Logger.LogInformation($"Resource {e.ResourceName} exists.", deviceId, binding);
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}