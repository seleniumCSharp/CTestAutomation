// <copyright file="VerifyAddOfficerTitleFromCommitteManagementTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Nunit.Tests
{
    using System.Collections.Generic;
    using MCS.Test.Automation.Tests.NUnit;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass;
    using NUnit.Framework;

    [TestFixture]
    public class VerifyAddOfficerTitleFromCommitteManagementTest : ProjectTestBase
    {
        [Test]
        [Category("smoke")]
        [TestCaseDescription(Id = "[MCS2-000] ", Name = " [Rules and Exceptions - Add Officer Title of Committe Mangement]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "addofficerData" })]
        public void VerifyAddingOfficerTitleOfCommitteManagement(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var committeManagementPage = new CommitteManagementPage(this.DriverContext);
            var manageOfficerTitlePage = new ManageOfficerTitlePage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsCommitteeManagementSectionClickable();
            string manageOfficerTitle = parameters["manageofficerTitle"].Trim();
            committeManagementPage.IsManageOffierTitlesClickable(manageOfficerTitle);
            string header = parameters["header"].Trim();
            manageOfficerTitlePage.IsManageOfficerTitleHeaderDisplayed(header);
        }
    }
}
