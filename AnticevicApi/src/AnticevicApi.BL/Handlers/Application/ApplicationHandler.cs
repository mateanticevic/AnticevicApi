﻿using AnticevicApi.DL.DbContexts;
using AnticevicApi.DL.Extensions;
using AnticevicApi.Extensions.BuiltInTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnticevicApi.BL.Handlers.Application
{
    public class ApplicationHandler : Handler<ApplicationHandler>, IApplicationHandler
    {
        public ApplicationHandler(IHandlerContext<ApplicationHandler> context) : base(context)
        {

        }

        public Dictionary<string, object> GetSettings(string applicationValueId)
        {
            using (var db = GetMainContext())
            {
                return db.Applications.Include(x => x.Settings)
                                      .SingleOrDefault(applicationValueId)
                                      .Settings
                                      .ToDictionary(x => x.Key, x => x.Value.ToProperType());
            }
        }
    }
}
