// <copyright file="LoginPage.cs" company="PlaceholderCompany">
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
    public class LoginPage : ProjectPageBase
#pragma warning restore SA1600 // Elements should be documented
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
loginlable = new ElementLocator(Locator.CssSelector, "h2");

        private readonly ElementLocator
usernametxt = new ElementLocator(Locator.Name, "username");

        private readonly ElementLocator
passwordtxt = new ElementLocator(Locator.Name, "password");

        private readonly ElementLocator
loginbtn = new ElementLocator(Locator.XPath, "//*[@class='ui primary button']");

        private string nmcustomerlogo = "Customer logo";
        private string nmusernametxt = "Username text field";
        private string nmpasswordtxt = "Password text field";
        private string nmloginbtn = "Login button";

        public LoginPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public LoginPage OpenLandingPage()
        {
            switch (BaseConfiguration.TestBrowser)
            {
                case BrowserType.Firefox:
                    var urlFF = BaseConfiguration.GetMCS2UrlValue;
                    this.Driver.NavigateToFirefox(new Uri(urlFF));
                    return this;
                case BrowserType.InternetExplorer:
                case BrowserType.IE:
                    var url = BaseConfiguration.GetMCS2UrlValue;
                    this.Driver.NavigateToIE(new Uri(url));
                    return this;
                case BrowserType.Chrome:
                    var urlchrome = BaseConfiguration.GetMCS2UrlValue;
                    this.Driver.NavigateTo(new Uri(urlchrome));
                    Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", BaseConfiguration.GetUrlValue);
                    return this;

                default:
                    throw new NotSupportedException(
                        string.Format(CultureInfo.CurrentCulture, "Driver {0} is not supported", BaseConfiguration.TestBrowser));
            }
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisibleWithSoftAssertion(this.customerLogo, this.nmcustomerlogo);
        }

        public void EnterUserName(string uname)
        {
            this.Driver.IsElementVisible(this.usernametxt.Format(uname), this.nmusernametxt);
            this.Driver.EnterText(this.usernametxt.Format(uname), uname, this.nmusernametxt);
        }

        public void EnterPassword(string password)
        {
            this.Driver.IsElementVisible(this.passwordtxt.Format(password), this.nmpasswordtxt);
            this.Driver.EnterText(this.passwordtxt.Format(password), password, this.nmpasswordtxt);
        }

        public void IsUserAbletoLoginMCSApp(string uname, string pass)
        {
            this.EnterUserName(uname);
            this.EnterPassword(pass);
            this.IsLoginButtonClickable();
        }

        public void IsLoginButtonClickable()
        {
            this.Driver.IsElementVisible(this.loginbtn, this.nmloginbtn);
            this.Driver.IsElementClickable(this.loginbtn, this.nmloginbtn);
        }
    }
}
