﻿// <copyright file="TakeScreenShot.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using MCS.Test.Automation.Common;
    using MCS.Test.Automation.Common.Extensions;
    using NLog;
    using OpenQA.Selenium;

    /// <summary>
    /// Custom screenshot solution
    /// </summary>
    public static class TakeScreenShot
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Takes screen shot.
        /// </summary>
        /// <returns>Image contains desktop screenshot</returns>
        public static Bitmap DoIt()
        {
            Logger.Info("****************************Taking*Screenshot***************************************");
            var screen = Screen.PrimaryScreen;
            using (var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    try
                    {
                        graphics.CopyFromScreen(0, 0, 0, 0, screen.Bounds.Size);
                    }
                    catch (Win32Exception)
                    {
                        Logger.Error("Win32Exception Exception, user is locked out with no access to windows desktop");
                        return null;
                    }

                    Logger.Error("Screenshot taken.");
                }

                return (Bitmap)bitmap.Clone();
            }
        }

        /// <summary>
        /// Saves the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="format">The format.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="title">The title.</param>
        /// <returns>The path to the saved bitmap, null if not saved.</returns>
        public static string Save(Bitmap bitmap, ImageFormat format, string folder, string title)
        {
            var fileName = string.Format(CultureInfo.CurrentCulture, "{0}_{1}_{2}.png", title, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.CurrentCulture), "fullscreen");
            fileName = Regex.Replace(fileName, "[^0-9a-zA-Z._]+", "_");
            fileName = NameHelper.ShortenFileName(folder, fileName, "_", 255);
            var filePath = Path.Combine(folder, fileName);

            if (bitmap == null)
            {
                Logger.Error("Full screenshot is not saved");
            }
            else
            {
                bitmap.Save(filePath, format);
                bitmap.Dispose();
                Logger.Error(CultureInfo.CurrentCulture, "Test failed: full screenshot saved to {0}.", filePath);
                FilesHelper.WaitForFileOfGivenName(BaseConfiguration.ShortTimeout, fileName, folder);
                Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "##teamcity[publishArtifacts '{0}']", filePath));
                return filePath;
            }

            return null;
        }

        /// <summary>
        /// Takes screen shot of specific element.
        /// </summary>
        /// <param name="element">Element to take screenshot</param>
        /// <param name="folder">Folder to save screenshot</param>
        /// <param name="screenshotName">Name of screenshot</param>
        /// <returns>Full path to taken screenshot</returns>
        /// <example>How to use it: <code>
        /// var el = this.Driver.GetElement(this.menu);
        /// var fullPath = TakeScreenShot.TakeScreenShotOfElement(el, TestContext.CurrentContext.TestDirectory + BaseConfiguration.ScreenShotFolder, "MenuOutSideTheIFrame");
        /// </code></example>
        public static string TakeScreenShotOfElement(IWebElement element, string folder, string screenshotName)
        {
            Logger.Debug("Taking screenhot of element not within iframe");
            return TakeScreenShotOfElement(0, 0, element, folder, screenshotName);
        }

        /// <summary>
        /// Takes screen shot of specific element within iframe.
        /// </summary>
        /// <param name="iframeLocationX">X coordinate of iframe</param>
        /// <param name="iframeLocationY">Y coordinate of iframe</param>
        /// <param name="element">Element to take screenshot</param>
        /// <param name="folder">Folder to save screenshot</param>
        /// <param name="screenshotName">Name of screenshot</param>
        /// <returns>Full path to taken screenshot</returns>
        /// <example>How to use it: <code>
        /// var iFrame = this.Driver.GetElement(this.iframe);
        /// int x = iFrame.Location.X;
        /// int y = iFrame.Location.Y;
        /// this.Driver.SwitchTo().Frame(0);
        /// var el = this.Driver.GetElement(this.elelemtInIFrame);
        /// var fullPath = TakeScreenShot.TakeScreenShotOfElement(x, y, el, TestContext.CurrentContext.TestDirectory + BaseConfiguration.ScreenShotFolder, "MenuOutSideTheIFrame");
        /// </code></example>
        public static string TakeScreenShotOfElement(int iframeLocationX, int iframeLocationY, IWebElement element, string folder, string screenshotName)
        {
            Logger.Debug("Taking screenhot of iframe LocationX:{0} LocationY:{1}", iframeLocationX, iframeLocationY);
            var locationX = iframeLocationX;
            var locationY = iframeLocationY;

            var driver = element.ToDriver();

            var screenshotDriver = (ITakesScreenshot)driver;
            var screenshot = screenshotDriver.GetScreenshot();
            var filePath = Path.Combine(folder, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff", CultureInfo.CurrentCulture) + "temporary_fullscreen.png");
            Logger.Debug(CultureInfo.CurrentCulture, "Taking full screenshot {0}", filePath);
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            if (BaseConfiguration.TestBrowser == BrowserType.Chrome)
            {
                locationX = element.Location.X + locationX;
                locationY = element.Location.Y + locationY;
            }
            else
            {
                locationX = element.Location.X;
                locationY = element.Location.Y;
            }

            var elementWidth = element.Size.Width;
            var elementHeight = element.Size.Height;

            Logger.Debug(CultureInfo.CurrentCulture, "Cutting out screenshot of element locationX:{0} locationY:{1} elementWidth:{2} elementHeight:{3}", locationX, locationY, elementWidth, elementHeight);

            var image = new Rectangle(locationX, locationY, elementWidth, elementHeight);
            var importFile = new Bitmap(filePath);
            string newFilePath;
            Bitmap cloneFile;
            try
            {
                newFilePath = Path.Combine(folder, screenshotName + ".png");
                cloneFile = (Bitmap)importFile.Clone(image, importFile.PixelFormat);
            }
            finally
            {
            importFile.Dispose();
            }

            Logger.Debug(CultureInfo.CurrentCulture, "Saving screenshot of element {0}", newFilePath);
            cloneFile.Save(newFilePath);
            File.Delete(filePath);
            return newFilePath;
        }
    }
}
