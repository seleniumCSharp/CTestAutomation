// <copyright file="Verify.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Types;
    using NLog;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using RelevantCodes.ExtentReports;
    using Assert = NUnit.Framework.Assert;

    /// <summary>
    /// Class for assert without stop tests
    /// </summary>
    public static class Verify
    {
        private static readonly NLog.Logger Logger = LogManager.GetLogger("TEST");

        /// <summary>
        /// Verify group of assets
        /// </summary>
        /// <param name="driverContext">Container for driver</param>
        /// <param name="myAsserts">Group asserts</param>
        /// <example>How to use it: <code>
        /// Verify.That(
        ///     this.DriverContext,
        ///     () => Assert.AreEqual(5 + 7 + 2, forgotPassword.EnterEmail(5, 7, 2)),
        ///     () => Assert.AreEqual("Your e-mail's been sent!", forgotPassword.ClickRetrievePassword));
        /// </code></example>
        public static void That(DriverContext driverContext, params Action[] myAsserts)
        {
            That(driverContext, false, false, myAsserts);
        }

        /// <summary>
        /// Verify group of assets
        /// </summary>
        /// <param name="driverContext">Container for driver</param>
        /// <param name="enableScreenShot">Enable screenshot</param>
        /// <param name="enableSavePageSource">Enable save page source</param>
        /// <param name="myAsserts">Group asserts</param>
        /// <example>How to use it: <code>
        /// Verify.That(
        ///     this.DriverContext,
        ///     true,
        ///     false,
        ///     () => Assert.AreEqual(5 + 7 + 2, forgotPassword.EnterEmail(5, 7, 2)),
        ///     () => Assert.AreEqual("Your e-mail's been sent!", forgotPassword.ClickRetrievePassword));
        /// </code></example>
        public static void That(DriverContext driverContext, bool enableScreenShot, bool enableSavePageSource, params Action[] myAsserts)
        {
            foreach (var myAssert in myAsserts)
            {
                That(driverContext, myAssert, false, false);
            }

            if (!driverContext.VerifyMessages.Count.Equals(0) && enableScreenShot)
            {
                driverContext.TakeAndSaveScreenshot();
            }

            if (!driverContext.VerifyMessages.Count.Equals(0) && enableSavePageSource)
            {
                driverContext.SavePageSource(driverContext.TestTitle);
            }
        }

        /// <summary>
        /// Verify assert conditions
        /// </summary>
        /// <param name="driverContext">Container for driver</param>
        /// <param name="myAssert">Assert condition</param>
        /// <param name="enableScreenShot">Enabling screenshot</param>
        /// <param name="enableSavePageSource">Enable save page source</param>
        /// <example>How to use it: <code>
        /// Verify.That(this.DriverContext, () => Assert.IsFalse(flag), true);
        /// </code></example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "removed ref to unit test")]
        public static void That(DriverContext driverContext, Action myAssert, bool enableScreenShot, bool enableSavePageSource)
        {
            try
            {
                myAssert();
            }
            catch (Exception e)
            {
                if (enableScreenShot)
                {
                    driverContext.TakeAndSaveScreenshot();
                }

                if (enableSavePageSource)
                {
                    driverContext.SavePageSource(driverContext.TestTitle);
                }

                driverContext.VerifyMessages.Add(new ErrorDetail(null, DateTime.Now, e));

                Logger.Error(CultureInfo.CurrentCulture, "<VERIFY FAILS>\n{0}\n</VERIFY FAILS>", e);
            }
        }

        /// <summary>
        /// Verify assert conditions
        /// </summary>
        /// <param name="driverContext">Container for driver</param>
        /// <param name="myAssert">Assert condition</param>
        /// <example>How to use it: <code>
        /// Verify.That(this.DriverContext, () => Assert.AreEqual(parameters["number"], links.CountLinks()));
        /// </code></example>
        public static void That(DriverContext driverContext, Action myAssert)
        {
            That(driverContext, myAssert, false, false);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "removed ref to unit test")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented
        public static void That(DriverContext driverContext, Action myAssert, string verifyMsg, string passMsg, string failMsg)
#pragma warning restore SA1600 // Elements must be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            try
            {
                myAssert();
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, verifyMsg, passMsg);
            }
            catch (Exception e)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, verifyMsg, failMsg);
                driverContext.VerifyMessages.Add(new ErrorDetail(null, DateTime.Now, e));

                Logger.Error(CultureInfo.CurrentCulture, "<VERIFY FAILS>\n{0}\n</VERIFY FAILS>", e);
            }
        }

        /// <summary>
        /// Verify assert conditions
        /// </summary>
        /// <param name="webDriver">Webdriver</param>
        /// <param name="driverContext">Container for driver</param>
        /// <param name="locator">element locator</param>
        /// <param name="name"> element name</param>
        /// <example>How to use it: <code>
        /// Verify.That(this.DriverContext, () => Assert.AreEqual(parameters["number"], links.CountLinks()));
        /// </code></example>
        /// <returns>bool</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "removed ref to unit test")]
        public static bool AreElementsVisibleWithSoftAssertion(this IWebDriver webDriver, DriverContext driverContext, ElementLocator locator, string name)
        {
            try
            {
                var webElementLocator = webDriver.GetElements(locator);
                ReadOnlyCollection<IWebElement> collection = new ReadOnlyCollection<IWebElement>(webElementLocator);
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(BaseConfiguration.MediumTimeout));
#pragma warning disable CS0618 // Type or member is obsolete
                wait.Until(condition: ExpectedConditions.VisibilityOfAllElementsLocatedBy(collection));
#pragma warning restore CS0618 // Type or member is obsolete
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify " + name + " are visible", name + " are visible successfully");
                Logger.Info(name + " are displayed/Enabled successfully");
                return true;
            }
            catch (Exception e)
            {
                driverContext.VerifyMessages.Add(new ErrorDetail(null, DateTime.Now, e));
                Logger.Error("An exception occured while waiting for the elements to become visible " + e.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify " + name + " are visible with in provided time " + BaseConfiguration.ShortTimeout, "An exception occurred waiting for " + name + " to become visible");
                Logger.Error(CultureInfo.CurrentCulture, "<VERIFY FAILS>\n{0}\n</VERIFY FAILS>", e);
                return false;
            }
        }

        /// <summary>
        /// Verify assert conditions
        /// </summary>
        /// <param name="webDriver">Webdriver</param>
        /// <param name="locator">element locator</param>
        /// <param name="name"> element name</param>
        /// <example>How to use it: <code>
        /// Verify.That(this.DriverContext, () => Assert.AreEqual(parameters["number"], links.CountLinks()));
        /// </code></example>
        /// <returns>bool</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "removed ref to unit test")]
        public static bool IsElementVisibleWithSoftAssertion(this IWebDriver webDriver, ElementLocator locator, string name)
        {
            try
            {
                webDriver.WaitForPageLoad();
                var webElementLocator = webDriver.GetElement(locator);
                if (webElementLocator.Displayed)
                {
                    webDriver.HighlightingWebElement(webElementLocator);

                }

                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify " + name + " is visible", name + " is visible successfully");

                // DriverContext.ExtentStepTest.Log(Status.Pass, name + " is displayed successfully");
                Logger.Info(name + " is displayed/Enabled successfully");
                return webElementLocator.Displayed;
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while waiting for the element to become visible " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify " + name + " is visible with in provided time " + BaseConfiguration.ShortTimeout, "An exception occurred waiting for " + name + " to become visible");
                return false;
            }
        }

        /// <summary>
        /// Validate Text Present on Element with SoftAssertion
        /// </summary>
        /// <param name="webDriver">This is webdriver</param>
        /// <param name="locator">Name of the Locator</param>
        /// <param name="name">Element Name</param>
        /// <param name="textTobeVerified"> text to be verified</param>
        /// <returns>bool..</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "removed ref to unit test")]
        public static bool ValiadteTextPresentOnElementWithSoftAssertion(this IWebDriver webDriver, ElementLocator locator, string name, string textTobeVerified)
        {
            bool flag = false;
            string actualText = null;
            try
            {
                if (IsElementVisibleWithSoftAssertion(webDriver, locator, name))
                {
                    var webElementLocator = webDriver.GetElement(locator);
                    actualText = webElementLocator.Text;

                    // Assert.Contains("Verifying expected text" + textTobeVerified + "is present or not on element " + name, actualText.Contains(textTobeVerified).ToString(), textTobeVerified.ToUpper(CultureInfo.CurrentCulture).Trim());
                    Assert.AreEqual(actualText.ToUpper(CultureInfo.CurrentCulture).Trim(), textTobeVerified.ToUpper(CultureInfo.CurrentCulture).Trim(), "Verifying expected text" + textTobeVerified + "is present or not on element " + name);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify expected text " + textTobeVerified + " is visible on " + name, textTobeVerified + " text is visible successfully");
                    Logger.Info(textTobeVerified + " is visible successfully");
                    flag = true;
                }

                return flag;
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while waiting for the element to become visible " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify expected " + textTobeVerified + " is visible on " + name, "Expected text: " + textTobeVerified + " is not matching with actual text:" + actualText);
                return flag;
            }
        }

        // public void IsHelpDropDownDisplayedWithSoftAssertion(string textToBeVerified)
        // {
        //    Verify.That(this.DriverContext, () => Assert.IsTrue(Verify.ValiadteTextPresentOnElementWithSoftAssertion(this.Driver, this.helpDropDown, this.nmhelpDropDown, textToBeVerified), "Verifying " + textToBeVerified + " is displayed"));
        // }
    }
}