// <copyright file="JsonContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit
{
    // using AventStack.ExtentReports;
    // using AventStack.ExtentReports.Reporter;
    // using AventStack.ExtentReports.Reporter.Configuration;

    /// <summary>
    /// The base class for all tests.
    /// </summary>
    public class JsonContext
    {
        public static string InfoSummary { get; set; }

        public static string InfoDescription { get; set; }

        public static string InfoVersion { get; set; }

        public static string InfoUser { get; set; }

        public static string InfoRevision { get; set; }

        public static string InfoStartDate { get; set; }

        public static string InfoFinishDate { get; set; }

        public static string InfoTestPlanKey { get; set; }

        public static string TestsTestKey { get; set; }

        public static string TestsStart { get; set; }

        public static string TestsFinish { get; set; }

        public static string TestsComment { get; set; }

        public static string TestsStatus { get; set; }

        public static string TestsEvidencesData { get; set; }

        public static string TestsEvidencesFileName { get; set; }

        public static string TestsEvidencesContentType { get; set; }

        public string TestTry { get; set; }
    }
}
