// <copyright file="TestData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.DataDriven
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using global::NUnit.Framework;

    /// <summary>
    /// DataDriven methods for NUnit test framework
    /// </summary>
    public static class TestData
    {
        public static IEnumerable Credentials
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "credential", new[] { "user", "password" }, "credential"); }
        }

        public static IEnumerable CredentialsExcel
        {
            get { return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "credential", new[] { "user", "password" }, "credentialExcel"); }
        }

        public static IEnumerable LinksSetTestName
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "links", new[] { "number" }, "Count_links"); }
        }

        public static IEnumerable Links
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "links"); }
        }

        public static IEnumerable NewDesignationRegistrationTestData
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "newdesignationregistration"); }
        }

        public static IEnumerable NewOrganizationRegistrationTestData
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "neworganizationregistration"); }
        }

        public static IEnumerable LinksExcel()
        {
            return DataDrivenHelper.ReadXlsxDataDriveFile(ProjectBaseConfiguration.DataDrivenFileXlsx, "links");
        }

        public static IEnumerable CredentialsCSV1()
        {
            var path = TestContext.CurrentContext.TestDirectory;
            path = string.Format(CultureInfo.CurrentCulture, "{0}{1}", path, @"\DataDriven\CreditTest.csv");
            return DataDrivenHelper.ReadDataDriveFileCsv1(path, new[] { "user", "password" });
        }

        public static IEnumerable GetDetailsFromXML(string filename)
        {
            return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, filename);
        }
    }
}
