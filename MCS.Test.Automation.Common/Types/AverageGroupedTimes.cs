﻿// <copyright file="AverageGroupedTimes.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Types
{
    /// <summary>
    /// AverageGroupedTimes class.
    /// </summary>
    public class AverageGroupedTimes
    {
        /// <summary>
        /// Gets or sets the name of the scenario.
        /// </summary>
        /// <value>
        /// The name of the scenario.
        /// </value>
        public string StepName { get; set; }

        /// <summary>
        /// Gets or sets the Driver.
        /// </summary>
        /// <value>
        /// The Driver.
        /// </value>
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the average duration.
        /// </summary>
        /// <value>
        /// The average duration.
        /// </value>
        public double AverageDuration { get; set; }

        /// <summary>
        /// Gets or sets the average duration.
        /// </summary>
        /// <value>
        /// The average duration.
        /// </value>
        public long Percentile90 { get; set; }
    }
}