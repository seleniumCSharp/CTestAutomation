// <copyright file="DateHelper.cs" company="MCS">
// Copyright (c) MCS. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Common.Helpers
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Contains useful actions connected with dates
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// Gets the tomorrow date.
        /// </summary>
        /// <value>
        /// The tomorrow date.
        /// </value>
        public static string TomorrowDate
        {
            get
            {
                return DateTime.Now.AddDays(1).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets Previous Day's date in the specified format.
        /// </summary>
        /// <value>
        /// The Previous date.
        /// </value>
        public static string PreviousDate
        {
            get
            {
                return DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current Date time stamp.
        /// </summary>
        /// <value>
        /// The current Date time stamp.
        /// </value>
        public static string CurrentDateTimeZoneStamp
        {
            get
            {
                return DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current time stamp.
        /// </summary>
        /// <value>
        /// The current time stamp.
        /// </value>
        public static string CurrentTimeStamp
        {
            get
            {
                return DateTime.Now.ToString("ddMMyyyyHHmmss", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        public static string CurrentDate
        {
            get
            {
                return DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets the future date.
        /// </summary>
        /// <param name="numberDaysToAddToNow">The number days to add from current date.</param>
        /// <returns>Date in future depends on parameter: numberDaysToAddToNow</returns>
        public static string GetFutureDate(int numberDaysToAddToNow)
        {
            return DateTime.Now.AddDays(numberDaysToAddToNow).ToString("ddMMyyyy", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Generate Random String
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">false or true</param>
        /// <returns>bool..</returns>
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
