﻿// <copyright file="ElementLocator.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Types
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Class that helps to define Kind and value for html elements.
    /// </summary>
    public class ElementLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementLocator"/> class.
        /// </summary>
        /// <example>How we define locator: <code>
        /// private readonly ElementLocator searchTextbox = new ElementLocator(Locator.Id, "SearchTextBoxId");
        /// </code> </example>
        /// <param name="kind">The locator type.</param>
        /// <param name="value">The locator value.</param>
        public ElementLocator(Locator kind, string value)
        {
            this.Kind = kind;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the kind of element locator.
        /// </summary>
        /// <value>
        /// Kind of element locator (Id, Xpath, ...).
        /// </value>
        public Locator Kind { get; set; }

        /// <summary>
        /// Gets or sets the element locator value.
        /// </summary>
        /// <value>
        /// The the element locator value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Formats the generic element locator definition and create the instance
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// New element locator with value changed by injected parameters
        /// </returns>
        /// <example>How we can replace parts of defined locator: <code>
        /// private readonly ElementLocator menuLink = new ElementLocator(Locator.XPath, "//*[@title='{0}' and @ms.title='{1}']");
        /// var element = this.Driver.GetElement(this.menuLink.Format("info","news"));
        /// </code></example>
        public ElementLocator Format(params object[] parameters)
        {
            return new ElementLocator(this.Kind, string.Format(CultureInfo.CurrentCulture, this.Value, parameters));
        }
    }
}