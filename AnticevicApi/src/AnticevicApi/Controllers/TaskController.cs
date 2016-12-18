﻿using AnticevicApi.BL.Handlers.Task;
using AnticevicApi.Model.Constants;
using AnticevicApi.Model.View.Task;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AnticevicApi.Controllers
{
    [Route("[controller]")]
    public class TaskController : BaseController<TaskController>
    {
        private readonly ITaskHandler _taskHandler;

        public TaskController(ILogger<TaskController> logger, ITaskHandler taskHandler) : base(logger)
        {
            _taskHandler = taskHandler;
        }

        #region Get

        [HttpGet]
        public IEnumerable<Task> Get(string status, string priority, string type)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(Get), status, priority, type);

            return _taskHandler.Get(status, priority, type);
        }

        #endregion
    }
}
