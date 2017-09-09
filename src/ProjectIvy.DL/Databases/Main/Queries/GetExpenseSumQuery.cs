﻿using System.Collections.Generic;
using ProjectIvy.DL.Databases.Main.UserTypes;
using ProjectIvy.DL.Extensions;
using static Dapper.SqlMapper;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ProjectIvy.DL.Databases.Main.Queries
{
    public class GetExpenseSumQuery : IDynamicParameters
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int UserId { get; set; }

        public int TargetCurrencyId { get; set; }

        public string ExpenseTypeValueId { get; set; }

        public string VendorValueId { get; set; }

        public IEnumerable<int> ExpenseIds { get; set; }

        public void AddParameters(IDbCommand command, Identity identity)
        {
            var sqlCommand = (SqlCommand)command;
            sqlCommand.CommandType = CommandType.Text;

            var intList = new IntList(ExpenseIds);

            sqlCommand.Parameters.Add(intList.ToSqlParameter(nameof(ExpenseIds)));        
            sqlCommand.Parameters.Add(From.ToSqlParameter(nameof(From)));
            sqlCommand.Parameters.Add(To.ToSqlParameter(nameof(To)));
            sqlCommand.Parameters.Add(UserId.ToSqlParameter(nameof(UserId)));
            sqlCommand.Parameters.Add(TargetCurrencyId.ToSqlParameter(nameof(TargetCurrencyId)));
            sqlCommand.Parameters.Add(VendorValueId.ToSqlParameter(nameof(VendorValueId)));
            sqlCommand.Parameters.Add(ExpenseTypeValueId.ToSqlParameter(nameof(ExpenseTypeValueId)));
        }
    }
}