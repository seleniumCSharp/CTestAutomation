﻿// <copyright file="LocatorExtensions.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Extensions
{
    using MCS.Test.Automation.Common.Types;

    using OpenQA.Selenium;

    /// <summary>
    /// Locator extensions methods for selenium
    /// </summary>
    public static class LocatorExtensions
    {
        /// <summary>
        /// From the locator to selenium by converter.
        /// </summary>
        /// <example>Using standard method FindElement, even we have locator as ElementLocator: <code>
        /// private readonly ElementLocator searchTextbox = new ElementLocator(Locator.Id, "SearchTextBoxId");
        /// this.Driver.FindElement(searchTextbox.ToBy());
        /// </code> </example>
        /// <param name="locator">The element locator.</param>
        /// <returns>The Selenium By</returns>
        public static By ToBy(this ElementLocator locator)
        {
            By by;
            switch (locator.Kind)
            {
                case Locator.Id:
                    by = By.Id(locator.Value);
                    break;
                case Locator.ClassName:
                    by = By.ClassName(locator.Value);
                    break;
                case Locator.CssSelector:
                    by = By.CssSelector(locator.Value);
                    break;
                case Locator.LinkText:
                    by = By.LinkText(locator.Value);
                    break;
                case Locator.Name:
                    by = By.Name(locator.Value);
                    break;
                case Locator.PartialLinkText:
                    by = By.PartialLinkText(locator.Value);
                    break;
                case Locator.TagName:
                    by = By.TagName(locator.Value);
                    break;
                case Locator.XPath:
                    by = By.XPath(locator.Value);
                    break;
                default:
                    by = By.Id(locator.Value);
                    break;
            }

            return by;
        }
    }
}
