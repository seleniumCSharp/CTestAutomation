// <copyright file="PerformanceHelper.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using MCS.Test.Automation.Common.Types;
    using NLog;

    /// <summary>
    /// Class which support performance tests. <see href="https://github.com/MCSLtd/Test.Automation/wiki/Performance%20measures">More details on wiki</see>
    /// </summary>
    public class PerformanceHelper
    {
        private static readonly Logger Logger = LogManager.GetLogger("DRIVER");

        /// <summary>
        /// The timer
        /// </summary>
        private readonly Stopwatch timer;

        /// <summary>
        /// The scenario list
        /// </summary>
        private readonly List<SavedTimes> loadTimeList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceHelper"/> class.
        /// </summary>
        public PerformanceHelper()
        {
            this.loadTimeList = new List<SavedTimes>();
            this.timer = new Stopwatch();
        }

        /// <summary>
        /// Gets the scenario list
        /// </summary>
        public IList<SavedTimes> GetloadTimeList => this.loadTimeList;

        /// <summary>
        /// Gets all the durations milliseconds.
        /// </summary>
        /// <returns>Return average load times for particular scenarios and browsers.</returns>
        public IEnumerable<AverageGroupedTimes> AllGroupedDurationsMilliseconds
        {
            get
            {
                var groupedList =
                    this.loadTimeList.OrderBy(dur => dur.Duration).GroupBy(
                        st => new { st.Scenario, BName = st.BrowserName },
                        (key, g) =>
                        {
                            var savedTimeses = g as IList<SavedTimes> ?? g.ToList();
                            return new AverageGroupedTimes
                            {
                                StepName = key.Scenario,
                                Browser = key.BName,
                                AverageDuration = Math.Round(savedTimeses.Average(dur => dur.Duration)),
                                Percentile90 = savedTimeses[(int)(Math.Ceiling(savedTimeses.Count * 0.9) - 1)].Duration
                            };
                        }).ToList().OrderBy(listElement => listElement.StepName);
                return groupedList;
            }
        }

        /// <summary>
        /// Gets or sets measured time.
        /// </summary>
        /// <value>Return last measured time.</value>
        private long MeasuredTime { get; set; }

        /// <summary>
        /// Starts the measure.
        /// </summary>
        public void StartMeasure()
        {
            this.timer.Reset();
            this.timer.Start();
        }

        /// <summary>
        /// Stops the measure.
        /// </summary>
        /// <param name="title">The title.</param>
        public void StopMeasure(string title)
        {
            this.timer.Stop();

            var savedTimes = new SavedTimes(title);
            this.MeasuredTime = this.timer.ElapsedMilliseconds;
            savedTimes.SetDuration(this.MeasuredTime);

            Logger.Info(CultureInfo.CurrentCulture, "Load Time {0}", this.MeasuredTime);

            this.loadTimeList.Add(savedTimes);
        }
    }
}
