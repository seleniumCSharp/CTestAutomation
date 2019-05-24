// <copyright file="VerifyAddMembershipClassificationTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using System.Threading;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass;

    [TestFixture]
    public class VerifyAddMembershipClassificationTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "[MCS2-544] ", Name = " [Rules and Exceptions - Add and save a new Member Classification]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "Classification" })]
        public void VerifyAddMembershipClassification(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipClassificationsClickable();
            homePage.IsAddClassificationTypeButtonClickable();
            string classificationType = parameters["ClassificationType"].Trim() + " on " + DateHelper.RandomString(3, false);
            string description = parameters["Description"].Trim() + " on " + DateHelper.CurrentTimeStamp;
            homePage.IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(classificationType);
            homePage.IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(description);
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            homePage.IsSuccessfullMessageForAddMembershioClassificationDisplayed();
        }
    }
}
