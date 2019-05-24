// <copyright file="HomePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.Compass
{
    using MCS.Test.Automation.Common;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Types;
    using MCS.Test.Automation.Tests.PageObjects;
    using NLog;

    public class HomePage : ProjectPageBase
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
              membershiptypeheader = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix h2");

        private readonly ElementLocator
             editMemeberShipTypeRecord = new ElementLocator(Locator.CssSelector, "i.pencil.icon");

        private readonly ElementLocator
            manageMemberClassifications = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(4)");

        private readonly ElementLocator
            addApplicationbtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            successfullMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
     applicationName = new ElementLocator(Locator.Name, "add_appName");

        private readonly ElementLocator
            contactName = new ElementLocator(Locator.Name, "add_contactName");

        private readonly ElementLocator
            emailId = new ElementLocator(Locator.Name, "add_email");

        private readonly ElementLocator
            savebtn = new ElementLocator(Locator.XPath, "//*[@class='column actions']/button[1]");

        private readonly ElementLocator
            cancelBtn = new ElementLocator(Locator.XPath, "//*[@class='column actions']/button[2]");

        private readonly ElementLocator
            addClassifficationTypebtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            addClassificationTypeheader = new ElementLocator(Locator.XPath, "//*[@class='ui modal transition visible active tiny']/div[1]");

        private readonly ElementLocator
            classificationtxt = new ElementLocator(Locator.XPath, "//*[@placeholder='Classification Type']");

        private readonly ElementLocator
            descriptiontxt = new ElementLocator(Locator.XPath, "//*[@name='Description']");

        private readonly ElementLocator
            classificationsavebtn = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            applicationError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Application Name is required.')]");

        private readonly ElementLocator
            contactError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Contact Name is required.')]");

        private readonly ElementLocator
            emailError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Email ID is required.')]");

        private readonly ElementLocator
             profilemenu = new ElementLocator(Locator.CssSelector, "div.loggedUserWrap");

        private readonly ElementLocator
            signOutLink = new ElementLocator(Locator.XPath, "//*[@class='loggedUserWrap']/div/div/div/span");

        private readonly ElementLocator
            classificationRecordList = new ElementLocator(Locator.XPath, "//*[@class='customTable']/tbody/tr/td/a");

        private readonly ElementLocator
            classificationTable = new ElementLocator(Locator.XPath, "//*[@class='customTable']/tbody");

        private readonly ElementLocator
            editClassificationRecord = new ElementLocator(Locator.CssSelector, "div.actions a.editBtn");

        private readonly ElementLocator
            loggedUser = new ElementLocator(Locator.CssSelector, "span.maxName.ellip");

        private readonly ElementLocator
            updatebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            membershipTypeList = new ElementLocator(Locator.CssSelector, "table.customTable.memberShipTable tbody tr td a");

        private string nmcustomerlogo = "Customer logo";
        private string nmeditMemeberShipTypeRecord = "Edit button";
        private string nmmembership = "Memebership Management Menu";
        private string nmcommitteemanagement = "Committee Management Menu";
        private string nmapplicationmanagement = "Application Management Menu";
        private string nmmanagememebershiptype = "Manage Membership Type option";
        private string nmmanagemembershipFaqs = "Manage Membership FAQ's option";
        private string nmmanagemembershipdocument = "Manage Membership Documents option";
        private string nmmanagememeberclassifications = "Manage Member Classifications option";
        private string nmaddapplicationbtn = "Add Application Button";
        private string nmapplicationname = "Application Name field";
        private string nmcontactName = "Contact Name field";
        private string nmemail = "Email Field";
        private string nmsavebtn = "Save button";
        private string nmCancelbtn = "Cancel button";
        private string nmAddClassificationTypeBtn = "Add Classification button";

        private string nmClassficationtxt = "Classfication Text field";
        private string nmClassificationDescrition = "Classification Description Text Field";
        private string nmclassificationsavebutton = "Save button";
        private string nmprofileMenu = "User Profile Menu";
        private string nmSignoutLink = "Sign Out";
        private string nmapplicationErrormsg = "Application Name is required.";
        private string nmcontactErrormsg = "Contact Name is required.";
        private string nmEmailErrormsgmsg = "Email ID is required.";
        private string nmclassificationrecordlist = "Classification Record";
        private string nmEditClassification = "Edit Classification record";
        private string nmsuccessfullmsg = "Membership Classification added Successfully";
        private string nmAddApplicationsuccessfullmsg = "Membership Application added Successfully";
        private string nmloggeduser = "Logged In User";
        private string nmmemebershiptypeheader = "Membership Types header";
        private string nmmembershiptypeList = "Membership Type from List of records";

        public HomePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsLoggedUserDisplayed()
        {
            this.Driver.IsElementVisibleWithSoftAssertion(this.loggedUser, this.nmloggeduser);
        }

        public void IsUpdateButtonClickable()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
            this.Driver.IsElementClickable(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsLoggedInUserDisplayed(string uname)
        {
            this.Driver.IsElementTextDisplayed(this.loggedUser.Format(uname), this.nmloggeduser);
        }

        public void IsMembershipTypeHeaderDisplayed(string header)
        {
            this.Driver.IsElementTextDisplayed(this.membershiptypeheader.Format(header), this.nmmemebershiptypeheader);
        }

        public void IsMembershipTypeRecordClickableFromList(string membershiptype)
        {
            this.Driver.WaitUntilElementIsFound(this.membershipTypeList, BaseConfiguration.LongTimeout);
            this.Driver.ClickOnMembershipTypeFromListofRecords(this.membershipTypeList, this.nmmembershiptypeList, membershiptype);
        }

        public void IsApplicationManagementSectionDisplayed()
        {
           // this.Driver.WaitUntilElementIsFound(this.applicationManagement, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.applicationManagement, this.nmapplicationmanagement);
        }

        public void IsMemebershipTypeRecordEditable()
        {
            this.Driver.IsElementVisible(this.editMemeberShipTypeRecord, this.nmeditMemeberShipTypeRecord);
            this.Driver.IsElementClickable(this.editMemeberShipTypeRecord, this.nmeditMemeberShipTypeRecord);
        }

        public void IsMembershipManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.membershipmenu, this.nmmembership);
            this.Driver.IsElementClickable(this.membershipmenu, this.nmmembership);
        }

        public void IsSuccessfullMessageForAddMembershioClassificationDisplayed()
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 60);
            this.Driver.IsElementVisibleWithSoftAssertion(this.successfullMsg, this.nmsuccessfullmsg);
        }

        public void AreAddApplicationValidationMessagesDisplayed(string appError, string contactError, string emailError)
        {
            this.Driver.IsElementVisible(this.applicationError.Format(appError), this.nmapplicationErrormsg);
            this.Driver.IsElementVisible(this.contactError.Format(contactError), this.nmcontactErrormsg);
            this.Driver.IsElementVisible(this.emailError.Format(emailError), this.nmEmailErrormsgmsg);
        }

        public void IsClassificationRecordEditable()
        {
            this.Driver.ClickonSelectedElementfromList(this.classificationRecordList, this.nmclassificationrecordlist, 0);
        }

        public void IsEditButtonClickable()
        {
            this.Driver.IsElementVisible(this.editClassificationRecord, this.nmEditClassification);
            this.Driver.IsElementClickable(this.editClassificationRecord, this.nmEditClassification);
        }

        public void IsCommitteeManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.committeemanagement, this.nmcommitteemanagement);
            this.Driver.IsElementClickable(this.committeemanagement, this.nmcommitteemanagement);
        }

        public void IsApplicationManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.applicationManagement, this.nmapplicationmanagement);
            this.Driver.IsElementClickable(this.applicationManagement, this.nmapplicationmanagement);
        }

        public void IsManageMembershipTypeClickable()
        {
            this.Driver.IsElementVisible(this.managemembershiptype, this.nmmanagememebershiptype);
            this.Driver.IsElementClickable(this.managemembershiptype, this.nmmanagememebershiptype);
        }

        public void IsManageMembershipFAQsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
            this.Driver.IsElementClickable(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
        }

        public void IsManageMembershipDocumentsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
            this.Driver.IsElementClickable(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
        }

        public void IsAddApplicationButtonClickable()
        {
            this.Driver.IsElementVisible(this.addApplicationbtn, this.nmaddapplicationbtn);
            var webElement = this.Driver.GetElement(this.addApplicationbtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsManageMembershipClassificationsClickable()
        {
            this.Driver.IsElementVisible(this.manageMemberClassifications, this.nmmanagememeberclassifications);
            this.Driver.IsElementClickable(this.manageMemberClassifications, this.nmmanagememeberclassifications);
        }

        public void IsAddClassificationTypeButtonClickable()
        {
            var webElement = this.Driver.GetElement(this.addClassifficationTypebtn);
            this.Driver.IsElementVisible(this.addClassifficationTypebtn, this.nmAddClassificationTypeBtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(string name)
        {
            this.Driver.IsElementVisible(this.classificationtxt, this.nmClassficationtxt);
            this.Driver.EnterText(this.classificationtxt, name, this.nmClassficationtxt);
        }

        public void IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(string name)
        {
            this.Driver.IsElementVisible(this.descriptiontxt, this.nmClassificationDescrition);
            this.Driver.EnterText(this.descriptiontxt, name, this.nmClassificationDescrition);
        }

        public void IsSaveButtonClickableOfPopUpWindowOfAddClassificationType()
        {
            this.Driver.IsElementVisible(this.classificationsavebtn, this.nmclassificationsavebutton);
            this.Driver.IsElementClickable(this.classificationsavebtn, this.nmclassificationsavebutton);
        }

        public void IsUserAbletoEnterApplicationName(string name)
        {
            this.Driver.IsElementVisible(this.applicationName.Format(name), this.nmapplicationname);
            this.Driver.EnterText(this.applicationName.Format(name), name, this.nmapplicationname);
        }

        public void IsUserAbletoEnterContactName(string name)
        {
            this.Driver.IsElementVisible(this.contactName.Format(name), this.nmcontactName);
            this.Driver.EnterText(this.contactName.Format(name), name, this.nmcontactName);
        }

        public void IsUserAbletoEnterEmailID(string name)
        {
            this.Driver.IsElementVisible(this.emailId.Format(name), this.nmemail);
            this.Driver.EnterText(this.emailId.Format(name), name, this.nmemail);
        }

        public void IsAddApplicationSaveButtonClickable()
        {
            this.Driver.IsElementVisible(this.savebtn, this.nmsavebtn);
            this.Driver.IsElementClickable(this.savebtn, this.nmsavebtn);
        }

        public void IsAddApplicationSuccessfullMessageDisplayed()
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 90);
            this.Driver.IsElementVisibleWithSoftAssertion(this.successfullMsg, this.nmAddApplicationsuccessfullmsg);
        }

        public void IsAddApplicationCancelButtonClickable()
        {
            this.Driver.IsElementVisible(this.cancelBtn, this.nmCancelbtn);
            this.Driver.IsElementClickable(this.cancelBtn, this.nmCancelbtn);
        }

        public void IsProfileMenuClickable()
        {
            this.Driver.IsElementVisible(this.profilemenu, this.nmprofileMenu);
            var webElement = this.Driver.GetElement(this.addClassifficationTypebtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsSignOutClickable()
        {
            this.IsProfileMenuClickable();
            this.Driver.IsUserMenuItemClickable(this.signOutLink, this.nmSignoutLink);
        }
    }
}
