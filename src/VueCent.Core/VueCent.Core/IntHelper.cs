// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IntHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Core
{
    /// <summary>
    /// Class IntHelper.
    /// </summary>
    public static class IntHelper
    {
        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Int32.</returns>
        public static int GetInt(this string str) => GetInt(str, 0);

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int32.</returns>
        public static int GetInt(this string str, int defaultValue) => int.TryParse(str, out int value) ? value : defaultValue;
    }
}