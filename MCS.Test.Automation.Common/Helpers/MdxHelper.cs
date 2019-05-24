// <copyright file="MdxHelper.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Helpers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Microsoft.AnalysisServices.AdomdClient;
    using NLog;

    /// <summary>
    /// Class is used for execution MDX queries and reading data from Analysis Services.
    /// </summary>
    public static class MdxHelper
    {
        /// <summary>
        /// NLog logger handle
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method is used for execution MDX query and reading each row from column.
        /// </summary>
        /// <param name="command">MDX query string.</param>
        /// <param name="connectionString">The Analysis Services connection string.</param>
        /// <param name="index">The index of column.</param>
        /// <returns>Collection of MDX query results</returns>
        /// <example>How to use it: <code>
        /// var connectionString = "Provider=MSOLAP.5;Password=password;Persist Security Info=True;User ID=username;Initial Catalog=AdventureWorks;Data Source=servername;MDX Compatibility=1;Safety Options=2;MDX Missing Member Mode=Error";
        /// const string SqlQuery = "Select [Measures].[Internet Average Sales Amount] on Columns, [Product].[Category].members on Rows From [AdventureWorks];";
        /// ICollection&lt;string&gt; result = MdxHelper.ExecuteMdxCommand(mdxQuery, connectionString, 1);
        /// </code></example>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Mdx injection is in this case expected.")]
        public static ICollection<string> ExecuteMdxCommand(string command, string connectionString, int index)
        {
            Logger.Debug(CultureInfo.CurrentCulture, "Send mdx query.");
            Logger.Debug(CultureInfo.CurrentCulture, "Query: {0}", command);
            Logger.Debug(CultureInfo.CurrentCulture, "AS connection string: {0}", connectionString);
            Logger.Debug(CultureInfo.CurrentCulture, "Index: {0}", index);

            var resultList = new List<string>();
            using (var connection = new AdomdConnection(connectionString))
            {
                connection.Open();

                using (var mdxCommand = new AdomdCommand(command, connection))
                {
                    using (var mdxReader = mdxCommand.ExecuteReader())
                    {
                        while (mdxReader.Read())
                        {
                            ////getName - column name
                            resultList.Add(mdxReader[index].ToString());
                        }
                    }
                }

                return resultList;
            }
        }
    }
}
