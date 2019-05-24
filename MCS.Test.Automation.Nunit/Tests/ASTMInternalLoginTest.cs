// <copyright file="ASTMInternalLoginTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass;

    [TestFixture]
    public class ASTMInternalLoginTest : ProjectTestBase
    {
        [Test]
        [Category("BVT_Internal")]
        [TestCaseDescription(Id = "[MCS2-482] ", Name = " [Rules and Exceptions - Login as Admin - Application Management]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternallogin" })]
        public void VerifyUserableToLoginToASTMInternalApplication(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
          }
    }
}
