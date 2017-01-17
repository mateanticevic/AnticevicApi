﻿namespace AnticevicApi.DL.Sql
{
    public static class MainSnippets
    {
        private const string _prefix = "AnticevicApi.DL.Sql.Main.";
        private const string _sufix = ".sql";

        public static string GetWebTimeSum = Build(nameof(GetWebTimeSum));

        private static string Build(string name)
        {
            return _prefix + name + _sufix;
        }
    }
}
