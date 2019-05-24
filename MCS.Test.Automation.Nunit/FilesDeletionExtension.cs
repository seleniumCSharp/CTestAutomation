// <copyright file="FilesDeletionExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit
{
    using System;
    using System.IO;

    // using AventStack.ExtentReports;
    // using AventStack.ExtentReports.Reporter;
    // using AventStack.ExtentReports.Reporter.Configuration;

    /// <summary>
    /// The base class for all file deletions.
    /// </summary>
    public static class FilesDeletionExtension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Need To provide defalt parameters")]
        public static void DeleteFilesWithExtension(string directoryPath, string fileExtension, bool deleteAll = false)
        {
            string[] files = Directory.GetFiles(directoryPath, fileExtension);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (!deleteAll)
                {
                    if (fi.LastWriteTime < DateTime.Now.AddDays(-3))
                    {
                        fi.Delete();
                    }
                }
                else
                {
                    fi.Delete();
                }
            }
        }
    }
}
