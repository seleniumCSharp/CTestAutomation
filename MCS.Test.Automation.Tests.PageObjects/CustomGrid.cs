// <copyright file="CustomGrid.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects
{
    using MCS.Test.Automation.Common.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Sample class to extends framework with new webElement
    /// </summary>
    public class CustomGrid : RemoteWebElement
    {
        /// <summary>
        /// The web element.
        /// </summary>
        private readonly IWebElement webElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomGrid"/> class.
        /// </summary>
        /// <param name="webElement">The webElement.</param>
        public CustomGrid(IWebElement webElement)
            : base(webElement.ToDriver() as RemoteWebDriver, null)
        {
            this.webElement = webElement;
        }

        /// <summary>
        /// Sample method to extends framework with new webElement and actions for it.
        /// </summary>
        /// <returns>Return true or false.</returns>
        private bool IsGridDisplayed()
        {
            return this.webElement.Displayed;
        }
    }
}
