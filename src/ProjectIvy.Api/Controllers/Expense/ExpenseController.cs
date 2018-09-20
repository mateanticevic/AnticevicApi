﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectIvy.BL.Handlers.Expense;
using ProjectIvy.Model.Binding.Expense;
using ProjectIvy.Model.Constants.Database;
using ProjectIvy.Model.Constants;
using ProjectIvy.Model.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using View = ProjectIvy.Model.View.Expense;

namespace ProjectIvy.Api.Controllers.Expense
{
    [Authorize(Roles = UserRole.User)]
    [Route("[controller]")]
    public class ExpenseController : BaseController<ExpenseController>
    {
        private readonly IExpenseHandler _expenseHandler;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseHandler expenseHandler) : base(logger)
        {
            _expenseHandler = expenseHandler;
        }

        #region Delete

        [HttpDelete("{valueId}")]
        public bool Delete(string valueId)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(Delete), valueId);

            return _expenseHandler.Delete(valueId);
        }

        #endregion

        #region Get

        [HttpGet("{expenseId}")]
        public View.Expense Get(string expenseId) => _expenseHandler.Get(expenseId);

        [HttpGet]
        public PagedView<View.Expense> Get(ExpenseGetBinding binding) => _expenseHandler.Get(binding);

        [HttpGet("Count")]
        public int GetCount([FromQuery] ExpenseGetBinding binding) => _expenseHandler.Count(binding);

        [HttpGet("Count/ByDay")]
        public IEnumerable<KeyValuePair<string, int>> GetCountByDay([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByDay(binding);

        [HttpGet("Count/ByDayOfWeek")]
        public IEnumerable<KeyValuePair<string, int>> GetCountByDayOfWekk([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByDayOfWeek(binding);

        [HttpGet("Count/ByMonth")]
        public IEnumerable<GroupedByMonth<int>> GetCountByMonth([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByMonth(binding);

        [HttpGet("Count/ByYear")]
        public IEnumerable<GroupedByYear<int>> GetCountByYear([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByYear(binding);

        [HttpGet("Count/ByPoi")]
        public PagedView<CountBy<Model.View.Poi.Poi>> GetCountByPoi([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByPoi(binding);

        [HttpGet("Count/ByType")]
        public PagedView<CountBy<Model.View.ExpenseType.ExpenseType>> GetCountByType([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByType(binding);

        [HttpGet("Count/ByVendor")]
        public PagedView<CountBy<Model.View.Vendor.Vendor>> GetCountByVendor([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountByVendor(binding);

        [HttpGet("{expenseId}/File")]
        public IEnumerable<View.ExpenseFile> GetFiles(string expenseId) => _expenseHandler.GetFiles(expenseId);

        [HttpGet("Sum")]
        public async Task<decimal> GetSum([FromQuery] ExpenseSumGetBinding binding) => await _expenseHandler.SumAmount(binding);

        [HttpGet("Sum/ByMonth")]
        public IEnumerable<GroupedByMonth<decimal>> GetGroupedByMonthSum([FromQuery] ExpenseSumGetBinding binding) => _expenseHandler.SumAmountByMonth(binding);

        [HttpGet("Sum/ByYear")]
        public IEnumerable<GroupedByYear<decimal>> GetGroupedByYearSum([FromQuery] ExpenseSumGetBinding binding) => _expenseHandler.SumAmountByYear(binding);

        [HttpGet("Sum/ByType")]
        public async Task<IEnumerable<KeyValuePair<string, decimal>>> GetGroupedByTypeSum([FromQuery] ExpenseSumGetBinding binding) => await _expenseHandler.SumByType(binding);

        [HttpGet("Type/Count")]
        public int GetTypesCount([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountTypes(binding);

        [HttpGet("Vendor/Count")]
        public int GetVendorsCount([FromQuery] ExpenseGetBinding binding) => _expenseHandler.CountVendors(binding);

        #endregion

        #region Put

        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] ExpenseBinding binding)
        {
            binding.Id = id;
            return _expenseHandler.Update(binding);
        }

        #endregion

        #region Post

        [HttpPost]
        public string Post([FromBody] ExpenseBinding binding) => _expenseHandler.Create(binding);

        [HttpPost("{expenseId}/File/{fileId}")]
        public IActionResult PostExpenseFile(string expenseId, string fileId, [FromBody] ExpenseFileBinding binding)
        {
            _expenseHandler.AddFile(expenseId, fileId, binding);

            return Ok();
        }

        #endregion
    }
}
