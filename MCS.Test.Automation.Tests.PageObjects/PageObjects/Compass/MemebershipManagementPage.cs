// <copyright file="MemebershipManagementPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Types;
    using MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using RelevantCodes.ExtentReports;

    public class MemebershipManagementPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
 customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
membershipname = new ElementLocator(Locator.Name, "MembershipTypeName");

        private readonly ElementLocator
membershipfee = new ElementLocator(Locator.Name, "FeeAmount");

        private readonly ElementLocator
nextbutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
          successfullMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
savebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
addmemebershiptype = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
          membershipList = new ElementLocator(Locator.CssSelector, "table.customTable.memberShipTable tbody tr td a");

        private string nmcustomerlogo = "Customer logo";
        private string nmaddmembershiptype = "Add Membership Type Button";
        private string nmmembershipname = "Membership Name field";
        private string nmmembershipfee = "Membership Fee field";
        private string nmNextbtn = "Next button";
        private string nmsuccessfullmsg = "Membership Type Details save Successfully";
        private string nmsavebtn = "Save button";

        public MemebershipManagementPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsMembershipNameAddedIntoResultsList()
        {
            throw new NotImplementedException();
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsAddMemberShipTypeButtonClickable()
        {
            this.Driver.IsElementVisible(this.addmemebershiptype, this.nmaddmembershiptype);
            this.Driver.IsElementClickable(this.addmemebershiptype, this.nmaddmembershiptype);
        }

        public void EnterMembershipFee(string name)
        {
            this.Driver.IsElementVisible(this.membershipfee.Format(name), this.nmmembershipfee);
            this.Driver.EnterText(this.membershipfee.Format(name), name, this.nmmembershipfee);
        }

        public void EnterMembershipName(string name)
        {
            this.Driver.IsElementVisible(this.membershipname.Format(name), this.nmmembershipname);
            this.Driver.EnterText(this.membershipname.Format(name), name, this.nmmembershipname);
        }

        public void IsNextButtonClickable()
        {
            this.Driver.IsElementVisible(this.nextbutton, this.nmNextbtn);
            this.Driver.IsElementClickable(this.nextbutton, this.nmNextbtn);
        }

        public void IsSuccessfullMessageDisplayed()
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 90);
            this.Driver.IsElementVisibleWithSoftAssertion(this.successfullMsg, this.nmsuccessfullmsg);
        }

        public void IsSaveButtonClickable()
        {
            this.Driver.IsElementVisible(this.savebutton, this.nmsavebtn);
            this.Driver.IsElementClickable(this.savebutton, this.nmsavebtn);
        }
    }
}
