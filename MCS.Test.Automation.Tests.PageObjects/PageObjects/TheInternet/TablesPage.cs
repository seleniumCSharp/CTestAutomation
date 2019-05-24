// <copyright file="TablesPage.cs" company="Objectivity Bespoke Software Specialists">
// Copyright (c) Objectivity Bespoke Software Specialists. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

using MCS.Test.Automation.Common;
using MCS.Test.Automation.Common.Extensions;
using MCS.Test.Automation.Common.Types;
using MCS.Test.Automation.Common.WebElements;

namespace MCS.Test.Automation.Tests.PageObjects.TheInternet
{

    public class TablesPage : ProjectPageBase
    {
        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
tableLocator = new ElementLocator(Locator.ClassName, "tablesorter");
        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
column = new ElementLocator(Locator.CssSelector, "tr td");
        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
row = new ElementLocator(Locator.CssSelector, "tbody tr");
        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
tagNameLocator = new ElementLocator(Locator.TagName, "th");
        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
xPathLocator = new ElementLocator(Locator.XPath, "//span");

        public TablesPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public string GetByTagNameLocator => this.Driver.GetElement(this.tagNameLocator).Text;

        public string GetByXpathLocator => this.Driver.GetElement(this.xPathLocator).Text;

        public string[][] GetTableElements()
        {
            return this.Driver.GetElement<Table>(this.tableLocator).GetTable(this.row, this.column);
        }
    }
}
