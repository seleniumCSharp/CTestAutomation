// <copyright file="VerifyAddandsaveanewapplicationTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass;

    [TestFixture]
    public class VerifyAddandsaveanewapplicationTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [Category("smoke")]
        [TestCaseDescription(Id = "[MCS2-493] ", Name = " [Rules and Exceptions - Add and save a new application]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddApplicationWithValidData" })]
        public void VerifyAddNewApplicationTest(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            homePage.IsAddApplicationButtonClickable();
            string applicationName = parameters["ApplicationName"].Trim() + " on " + DateHelper.RandomString(2,  false);
            string contact_Name = parameters["contactName"].Trim() + " on " + DateHelper.RandomString(2, false);
            homePage.IsUserAbletoEnterApplicationName(applicationName);
            homePage.IsUserAbletoEnterContactName(contact_Name);
            homePage.IsUserAbletoEnterEmailID(parameters["Email"].Trim());
            homePage.IsAddApplicationSaveButtonClickable();
            homePage.IsAddApplicationSuccessfullMessageDisplayed();
        }

        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "[MCS2-000] ", Name = " [Rules and Exceptions - Add application without data and check the error message]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddApplicationWithEmptyData" })]
        public void VerifyErrorMessageAddNewApplicationWithEmptyData(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            homePage.IsAddApplicationButtonClickable();
            homePage.IsUserAbletoEnterApplicationName(parameters["ApplicationName"].Trim());
            homePage.IsUserAbletoEnterContactName(parameters["contactName"].Trim());
            homePage.IsUserAbletoEnterEmailID(parameters["Email"].Trim());
            homePage.IsAddApplicationSaveButtonClickable();
            homePage.AreAddApplicationValidationMessagesDisplayed(parameters["applicationError"].Trim(), parameters["contacterror"].Trim(), parameters["emailerror"].Trim());
        }
    }
}
