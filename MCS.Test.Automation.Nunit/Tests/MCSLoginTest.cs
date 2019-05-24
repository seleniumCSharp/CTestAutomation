// <copyright file="MCSLoginTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass;

    [TestFixture]
    public class MCSLoginTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "MCS2-482", Name = "Rules and Exceptions - Login as Admin - Application Management")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "mcslogin" })]
        public void VerifyUserableToLoginMCS2Application(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionDisplayed();
        }
    }
}
