// <copyright file="VerifyEditMembershipClassificationTest.cs" company="PlaceholderCompany">
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
    public class VerifyEditMembershipClassificationTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "[MCS2-554] ", Name = " [Rules and Exceptions -Edit and Save Member Classification details]")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "Classification" })]
        public void VerifyEditMembershipClassification(Dictionary<string, string> parameters)
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
            homePage.IsClassificationRecordEditable();
            homePage.IsEditButtonClickable();
            string classificationType = parameters["ClassificationType"].Trim() + " on " + DateHelper.RandomString(3, false);
            homePage.IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(classificationType);
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            homePage.IsSuccessfullMessageForAddMembershioClassificationDisplayed();
        }
    }
}
