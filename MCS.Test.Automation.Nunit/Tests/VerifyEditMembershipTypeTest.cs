// <copyright file="VerifyEditMembershipTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyEditMembershipTypeTest : ProjectTestBase
    {
        [Test]
        [Category("BVT")]
        [TestCaseDescription(Id = "MCS2-622", Name = "Rules and Exceptions – Member Management –Edit Membership Type list –  Edit and Update")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditMembershipType" })]
        public void VerifyUserAbletoEditManageMembershipType(Dictionary<string, string> parameters)
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
            string header = parameters["header"].Trim();
            string membershipType = parameters["membershipType"].Trim();
            homePage.IsMembershipTypeHeaderDisplayed(header);
            homePage.IsMembershipTypeRecordClickableFromList(membershipType);
            homePage.IsMemebershipTypeRecordEditable();
            homePage.IsUpdateButtonClickable();
        }
    }
}
