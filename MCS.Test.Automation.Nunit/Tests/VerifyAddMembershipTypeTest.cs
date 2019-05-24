// <copyright file="VerifyAddMembershipTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddMembershipTypeTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "MCS2-532", Name = "Rules and Exceptions -Add Membership Type page-Add and Save Membership Type")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "MembershipType" })]
        public void VerifyUserAbletoAddManageMembershipType(Dictionary<string, string> parameters)
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
            homePage.IsManageMembershipTypeClickable();
            membershipManagementPage.IsAddMemberShipTypeButtonClickable();
            membershipManagementPage.EnterMembershipName(parameters["membershipname"].Trim() + DateHelper.RandomString(3, false));
            membershipManagementPage.EnterMembershipFee(parameters["membershipfee"].Trim());
            membershipManagementPage.IsNextButtonClickable();
            membershipManagementPage.IsSaveButtonClickable();
            membershipManagementPage.IsSuccessfullMessageDisplayed();
        }
    }
}
