// <copyright file="BrowserType.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common
{
    /// <summary>
    /// Supported browsers
    /// </summary>
    public enum BrowserType
    {
        /// <summary>
        /// Firefox browser
        /// </summary>
        Firefox,

        /// <summary>
        /// Firefox portable
        /// </summary>
        FirefoxPortable,

        /// <summary>
        /// InternetExplorer browser
        /// </summary>
        InternetExplorer,

        /// <summary>
        /// InternetExplorer browser
        /// </summary>
        IE,

        /// <summary>
        /// Chrome browser
        /// </summary>
        Chrome,

        /// <summary>
        /// Safari browser
        /// </summary>
        Safari,

        /// <summary>
        /// Remote Web driver
        /// </summary>
        RemoteWebDriver,

        /// <summary>
        /// Edge driver
        /// </summary>
        Edge,

        /// <summary>
        /// CloudProvider parallel cross browsers testing
        /// </summary>
        CloudProvider,

        /// <summary>
        /// Browser type to run test on Android with CloudProviders
        /// </summary>
        Android,

        /// <summary>
        /// Browser type to run test on Iphone with CloudProviders
        /// </summary>
        Iphone,

        /// <summary>
        /// Not supported browser
        /// </summary>
        None
    }
}
