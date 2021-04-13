// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="DoubleHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Core
{
    /// <summary>
    /// Class DoubleHelper.
    /// </summary>
    public static class DoubleHelper
    {
        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Double.</returns>
        public static double GetDouble(this string str) => GetDouble(str, 0.0);

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Double.</returns>
        public static double GetDouble(this string str, double defaultValue) => double.TryParse(str, out double value) ? value : defaultValue;
    }
}