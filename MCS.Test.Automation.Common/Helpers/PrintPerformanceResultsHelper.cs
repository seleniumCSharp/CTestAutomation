// <copyright file="PrintPerformanceResultsHelper.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Helpers
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using NLog;

    /// <summary>
    /// Class which support displaying performance test results. <see href="https://github.com/MCSLtd/Test.Automation/wiki/Performance%20measures">More details on wiki</see>
    /// </summary>
    public static class PrintPerformanceResultsHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Prints the performance summary of percentiles 90 duration in millisecond in Teamcity.
        /// </summary>
        /// <param name="measures">The instance of PerformanceHelper class.</param>
        public static void PrintPercentiles90DurationMillisecondsinTeamcity(PerformanceHelper measures)
        {
            var groupedPercentiles90Durations = measures.AllGroupedDurationsMilliseconds.Select(v =>
                "##teamcity[testStarted name='" + v.StepName + "." + v.Browser + ".Percentile90Line']\n" +
                "##teamcity[testFinished name='" + v.StepName + "." + v.Browser + ".Percentile90Line' duration='" + v.Percentile90 + "']\n" +
                v.StepName + " " + v.Browser + " Percentile90Line: " + v.Percentile90).ToList().OrderBy(listElement => listElement);

            for (int i = 0; i < groupedPercentiles90Durations.Count(); i++)
            {
                Logger.Info(groupedPercentiles90Durations.ElementAt(i));
            }
        }

        /// <summary>
        /// Prints the performance summary of average duration in millisecond in TeamCity.
        /// </summary>
        /// <param name="measures">The instance of PerformanceHelper class.</param>
        public static void PrintAverageDurationMillisecondsInTeamcity(PerformanceHelper measures)
        {
            var groupedAverageDurations = measures.AllGroupedDurationsMilliseconds.Select(v =>
                "\n##teamcity[testStarted name='" + v.StepName + "." + v.Browser + ".Average']" +
                "\n##teamcity[testFinished name='" + v.StepName + "." + v.Browser + ".Average' duration='" + v.AverageDuration + "']" +
                "\n" + v.StepName + " " + v.Browser + " Average: " + v.AverageDuration + "\n").ToList().OrderBy(listElement => listElement);

            for (int i = 0; i < groupedAverageDurations.Count(); i++)
            {
                Logger.Info(groupedAverageDurations.ElementAt(i));
            }
        }

        /// <summary>
        /// Prints the performance summary of percentiles 90 duration in millisecond in AppVeyor.
        /// </summary>
        /// <param name="measures">The instance of PerformanceHelper class.</param>
        public static void PrintPercentiles90DurationMillisecondsInAppVeyor(PerformanceHelper measures)
        {
            var groupedDurationsAppVeyor = measures.AllGroupedDurationsMilliseconds.Select(v =>
                v.StepName + "." + v.Browser +
                ".Percentile90Line -Framework NUnit -Filename PerformanceResults -Outcome Passed -Duration " + v.Percentile90)
                .ToList()
                .OrderBy(listElement => listElement);

            PrintResultsInAppVeyor(groupedDurationsAppVeyor);
        }

        /// <summary>
        /// Prints the performance summary of average duration in millisecond in AppVeyor.
        /// </summary>
        /// <param name="measures">The instance of PerformanceHelper class.</param>
        public static void PrintAverageDurationMillisecondsInAppVeyor(PerformanceHelper measures)
        {
            var groupedDurationsAppVeyor = measures.AllGroupedDurationsMilliseconds.Select(v =>
                v.StepName + "." + v.Browser +
                ".Average -Framework NUnit -Filename PerformanceResults -Outcome Passed -Duration " + v.AverageDuration)
                .ToList()
                .OrderBy(listElement => listElement);

            PrintResultsInAppVeyor(groupedDurationsAppVeyor);
        }

        /// <summary>
        /// Prints test results in AppVeyor
        /// </summary>
        /// <param name="measuresToPrint">Average load times for particular scenarios and browsers</param>
        public static void PrintResultsInAppVeyor(IOrderedEnumerable<string> measuresToPrint)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "appveyor";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            for (int i = 0; i < measuresToPrint.Count(); i++)
            {
                startInfo.Arguments = "AddTest " + measuresToPrint.ElementAt(i);

                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        if (exeProcess != null)
                        {
                            exeProcess.WaitForExit();
                        }
                    }
                }
                catch (Win32Exception)
                {
                    Logger.Info("AppVeyor app not found");
                    break;
                }
            }
        }
    }
}
