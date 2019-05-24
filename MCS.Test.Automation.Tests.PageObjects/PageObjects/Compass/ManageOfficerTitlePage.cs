// <copyright file="ManageOfficerTitlePage.cs" company="PlaceholderCompany">
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

#pragma warning disable SA1600 // Elements should be documented
    public class ManageOfficerTitlePage : ProjectPageBase
#pragma warning restore SA1600 // Elements should be documented
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
membershipmenu = new ElementLocator(Locator.CssSelector, "i.address.card.icon");

        private readonly ElementLocator
committeemanagement = new ElementLocator(Locator.CssSelector, "i.users.icon");

        private readonly ElementLocator
            applicationManagement = new ElementLocator(Locator.CssSelector, "i.cog.icon");

        private readonly ElementLocator
            managemembershiptype = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(1)");

        private readonly ElementLocator
            manageMembershipFAQs = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(2)");

        private readonly ElementLocator
            manageMembershipDocuments = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(3)");

        private readonly ElementLocator
            manageMemberClassifications = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(4)");

        private readonly ElementLocator
            officerTitleheader = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix h2");

        private string nmcustomerlogo = "Customer logo";
        private string nmmembership = "Memebership Management Menu";
        private string nmcommitteemanagement = "Committee Management Menu";
        private string nmapplicationmanagement = "Application Management Menu";
        private string nmmanagememebershiptype = "Manage Membership Type option";
        private string nmmanagemembershipFaqs = "Manage Membership FAQ's option";
        private string nmmanagemembershipdocument = "Manage Membership Documents option";
        private string nmmanagememeberclassifications = "Manage Member Classifications option";
        private string nmofficerTitleheader = "Officer Titles header";

#pragma warning disable SA1600 // Elements should be documented
        public ManageOfficerTitlePage(DriverContext driverContext)
#pragma warning restore SA1600 // Elements should be documented
            : base(driverContext)
        {
        }

        /// <summary>
        /// Customer Logo.
        /// </summary>
        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        /// <summary>
        /// Memebership Management.
        /// </summary>
        /// <param name="name">Name of the Element.</param>
        public void IsMembershipManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.membershipmenu.Format(name), this.nmmembership);
            this.Driver.IsElementClickable(this.membershipmenu.Format(name), this.nmmembership);
        }

        /// <summary>
        /// Committee Management Section.
        /// </summary>
        /// <param name="name">Element Name</param>
        public void IsCommitteeManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.committeemanagement.Format(name), this.nmcommitteemanagement);
            this.Driver.IsElementClickable(this.committeemanagement.Format(name), this.nmcommitteemanagement);
        }

        /// <summary>
        /// Application Management Section.
        /// </summary>
        /// <param name="name">Element Name.</param>
        public void IsApplicationManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.applicationManagement.Format(name), this.nmapplicationmanagement);
            this.Driver.IsElementClickable(this.applicationManagement.Format(name), this.nmapplicationmanagement);
        }

        public void IsManageOfficerTitleHeaderDisplayed(string header)
        {
            this.Driver.IsElementVisible(this.officerTitleheader.Format(header), this.nmofficerTitleheader);
        }

        /// <summary>
        /// Manage Memebership Type.
        /// </summary>
        /// <param name="name">Element Name</param>
        public void IsManageMembershipTypeClickable(string name)
        {
            this.Driver.IsElementVisible(this.managemembershiptype.Format(name), this.nmmanagememebershiptype);
            this.Driver.IsElementClickable(this.managemembershiptype.Format(name), this.nmmanagememebershiptype);
        }

        /// <summary>
        /// Manage Memebership FAqs.
        /// </summary>
        /// <param name="name">Element Name.</param>
        public void IsManageMembershipFAQsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
            this.Driver.IsElementClickable(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
        }

        /// <summary>
        /// Manage Memebership Documents.
        /// </summary>
        /// <param name="name">Element Name.</param>
        public void IsManageMembershipDocumentsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
            this.Driver.IsElementClickable(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
        }

        /// <summary>
        /// Manage Memebership Classification option.
        /// </summary>
        /// <param name="name">Element Name.</param>
        public void IsManageMembershipClassificationsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMemberClassifications.Format(name), this.nmmanagememeberclassifications);
            this.Driver.IsElementClickable(this.manageMemberClassifications.Format(name), this.nmmanagememeberclassifications);
        }
    }
}
