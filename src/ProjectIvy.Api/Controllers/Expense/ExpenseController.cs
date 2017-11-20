﻿using ProjectIvy.BL.Handlers.Expense;
using ProjectIvy.Model.Binding.Common;
using ProjectIvy.Model.Binding.Expense;
using ProjectIvy.Model.Constants.Database;
using ProjectIvy.Model.Constants;
using ProjectIvy.Model.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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
        public View.Expense Get(string expenseId)
        {
            return _expenseHandler.Get(expenseId);
        }

        [HttpGet]
        public PagedView<View.Expense> Get(ExpenseGetBinding binding)
        {
            return _expenseHandler.Get(binding);
        }

        [HttpGet("Count")]
        public int GetCount([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(Delete), from, to);

            return _expenseHandler.Count(new FilteredBinding(from, to));
        }

        [HttpGet("{expenseId}/File")]
        public IEnumerable<View.ExpenseFile> GetFiles(string expenseId)
        {
            return _expenseHandler.GetFiles(expenseId);
        }

        [HttpGet("Sum")]
        public async Task<decimal> GetSum([FromQuery] ExpenseSumGetBinding binding)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(GetSum), binding);

            return await _expenseHandler.GetSum(binding);
        }

        [HttpGet("Sum/Month")]
        public async Task<IEnumerable<GroupedByMonth<decimal>>> GetGroupedByMonthSum([FromQuery] ExpenseSumGetBinding binding)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(GetGroupedByMonthSum), binding);

            return await _expenseHandler.GetGroupedByMonthSum(binding);
        }

        [HttpGet("Sum/Year")]
        public async Task<IEnumerable<GroupedByYear<decimal>>> GetGroupedByYearSum([FromQuery] ExpenseSumGetBinding binding)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(GetGroupedByYearSum), binding);

            return await _expenseHandler.GetGroupedByYearSum(binding);
        }

        [HttpGet("Sum/Type")]
        public async Task<IEnumerable<KeyValuePair<string, decimal>>> GetGroupedByTypeSum([FromQuery] ExpenseSumGetBinding binding)
        {
            Logger.LogInformation((int)LogEvent.ActionCalled, nameof(GetGroupedByTypeSum), binding);

            return await _expenseHandler.GetGroupedByTypeSum(binding);
        }

        [HttpGet("Type/Count")]
        public int GetTypesCount([FromQuery] ExpenseGetBinding binding)
        {
            return _expenseHandler.CountTypes(binding);
        }

        [HttpGet("Vendor/Count")]
        public int GetVendorsCount([FromQuery] ExpenseGetBinding binding)
        {
            return _expenseHandler.CountVendors(binding);
        }

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
        public string Post([FromBody] ExpenseBinding binding)
        {
            return _expenseHandler.Create(binding);
        }

        [HttpPost("{expenseId}/File/{fileId}")]
        public IActionResult PostExpenseFile(string expenseId, string fileId, [FromBody] ExpenseFileBinding binding)
        {
            _expenseHandler.AddFile(expenseId, fileId, binding);

            return Ok();
        }

        #endregion
    }
}
