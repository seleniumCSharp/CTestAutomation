// <copyright file="DriverOptionsSetEventArgs.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common
{
    using System;
    using OpenQA.Selenium;

    /// <summary>
    /// Before Capabilities Set Handler.
    /// </summary>
    public class DriverOptionsSetEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverOptionsSetEventArgs" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DriverOptionsSetEventArgs(DriverOptions options)
        {
            this.DriverOptions = options;
        }

        /// <summary>
        /// Gets the current capabilities
        /// </summary>
        public DriverOptions DriverOptions { get; }
    }
}