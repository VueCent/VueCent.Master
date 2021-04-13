// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="DateTimeHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace VueCent.Core
{
    /// <summary>
    /// Class DateTimeHelper.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetDateTime(this string str) => GetDateTime(str, (DateTime)typeof(DateTime).GetDefault());

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetDateTime(this string str, DateTime defaultValue) => DateTime.TryParse(str, out DateTime value) ? value : defaultValue;

        /// <summary>
        /// Converts to unix.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>System.Int64.</returns>
        public static long ToUnix(this DateTime time) => (long)(time - Convert.ToDateTime("1970/01/01 00:00:00")).TotalMilliseconds;

        /// <summary>
        /// Des the unix.
        /// </summary>
        /// <param name="unix">The unix.</param>
        /// <returns>DateTime.</returns>
        public static DateTime DeUnix(this long unix) => Convert.ToDateTime("1970/01/01 00:00:00").AddMilliseconds(unix);

        /// <summary>
        /// Gets the time start.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetTimeStart(this DateTime time) => DateTime.Parse($"{ time.Year}/{time.Month}/{time.Day} 00:00:00");

        /// <summary>
        /// Gets the time end.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime GetTimeEnd(this DateTime time) => DateTime.Parse($"{time.Year}/{time.Month}/{time.Day} 23:59:59");
    }
}