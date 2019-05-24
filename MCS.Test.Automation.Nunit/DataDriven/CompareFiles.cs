// <copyright file="CompareFiles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.DataDriven
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
#pragma warning disable SA1210 // Using directives should be ordered alphabetically by namespace
    using MCS.Test.Automation.Tests.NUnit;
#pragma warning restore SA1210 // Using directives should be ordered alphabetically by namespace
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using NLog;

    /// <summary>
    /// DataDriven comparing files  methods for NUnit test framework <see href="https://github.com/MCSLtd/Test.Automation/wiki/Comparing-files-by-NUnit-DataDriven-tests">More details on wiki</see>
    /// </summary>
    public static class CompareFiles
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the comma-separated values file to compare.
        /// </summary>
        public static IEnumerable GetCsvFileToCompare
        {
            get
            {
                return FindFiles(FileType.Csv);
            }
        }

        /// <summary>
        /// Gets the txt file to compare.
        /// </summary>
        public static IEnumerable GetTxtFileToCompare
        {
            get
            {
                return FindFiles(FileType.Txt);
            }
        }

        /// <summary>
        /// Get files to compare.
        /// </summary>
        /// <param name="type">Files type</param>
        /// <returns>
        /// Pairs of files to compare <see cref="IEnumerable"/>.
        /// </returns>
        private static IEnumerable<TestCaseData> FindFiles(FileType type)
        {
            Logger.Info("Get Files {0}:", type);
            var liveFiles = FilesHelper.GetFilesOfGivenType(ProjectBaseConfiguration.DownloadFolderPath, type, "live");

            if (liveFiles != null)
            {
                foreach (FileInfo liveFile in liveFiles)
                {
                    Logger.Trace("liveFile: {0}", liveFile);

                    var fileNameBranch = liveFile.Name.Replace("live", "branch");
                    var testCaseName = liveFile.Name.Replace("_" + "live", string.Empty);

                    TestCaseData data = new TestCaseData(liveFile.Name, fileNameBranch);
                    data.SetName(Regex.Replace(testCaseName, @"[.]+|\s+", "_"));

                    Logger.Trace("file Name Short: {0}", testCaseName);

                    yield return data;
                }
            }
        }
    }
}
