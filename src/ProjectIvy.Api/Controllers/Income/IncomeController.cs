﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectIvy.Business.Handlers.Income;
using ProjectIvy.Model.Binding;
using ProjectIvy.Model.Binding.Income;
using ProjectIvy.Model.Constants.Database;
using ProjectIvy.Model.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using View = ProjectIvy.Model.View.Income;

namespace ProjectIvy.Api.Controllers.Income
{
    [Authorize(Roles = UserRole.User)]
    public class IncomeController : BaseController<IncomeController>
    {
        private readonly IIncomeHandler _incomeHandler;

        public IncomeController(ILogger<IncomeController> logger, IIncomeHandler incomeHandler) : base(logger) => _incomeHandler = incomeHandler;

        [HttpGet]
        public PagedView<View.Income> Get([FromQuery] IncomeGetBinding binding) => _incomeHandler.Get(binding);

        [HttpGet("Count")]
        public int GetCount([FromQuery] FilteredBinding binding) => _incomeHandler.GetCount(binding);

        [HttpGet("Sum")]
        public async Task<decimal> GetSum([FromQuery] IncomeGetSumBinding binding) => await _incomeHandler.GetSum(binding);

        [HttpGet("Sum/ByMonth")]
        public IEnumerable<GroupedByMonth<decimal>> GetSumByMonth([FromQuery] IncomeGetSumBinding binding) => _incomeHandler.GetSumByMonth(binding);

        [HttpGet("Sum/ByYear")]
        public IEnumerable<GroupedByYear<decimal>> GetSumByYear([FromQuery] IncomeGetSumBinding binding) => _incomeHandler.GetSumByYear(binding);
    }
}
