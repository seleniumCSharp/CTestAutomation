// <copyright file="Cell.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.WebElements
{
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Types;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using System.Globalization;
    using System.Threading;

    public class Cell : RemoteWebElement
    {
        private readonly string cellView;
        IWebElement webElement;
        public Cell(IWebElement webElement, ElementLocator locator)
            : base(webElement.ToDriver() as RemoteWebDriver, null)
        {
            this.webElement = webElement;
            var id = webElement.GetAttribute("id");
            this.cellView = string.Format(CultureInfo.InvariantCulture, "$('#{0}').data('kendoTreeView')", id);
        }

        public string Text
        {
            get { return webElement.Text; }
        }

        public void Click()
        {
            webElement.Click();
            ////Wait Two Second for Cell to change from label to drop down or text box
            Thread.Sleep(2000);
        }
                 }
}
