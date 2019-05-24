// <copyright file="Checkbox.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.WebElements
{
    using MCS.Test.Automation.Common.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Contains methods for checkbox.
    /// </summary>
    public class Checkbox : RemoteWebElement
    {
        /// <summary>
        /// The web element
        /// </summary>
        private readonly IWebElement webElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkbox"/> class.
        /// </summary>
        /// <param name="webElement">The webElement.</param>
        public Checkbox(IWebElement webElement)
            : base(webElement.ToDriver() as RemoteWebDriver, null)
        {
            this.webElement = webElement;
        }

        /// <summary>
        /// Set check box.
        /// </summary>
        public void TickCheckbox()
        {
            if (!this.webElement.Selected)
            {
                this.webElement.Click();
            }
        }

        /// <summary>
        /// Clear the check box.
        /// </summary>
        public void UntickCheckbox()
        {
            if (this.webElement.Selected)
            {
                this.webElement.Click();
            }
        }
    }
}
