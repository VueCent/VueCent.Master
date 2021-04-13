// ***********************************************************************
// Assembly         : VueCent.Log
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Level.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Log
{
    /// <summary>
    /// Enum Level
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// The trace
        /// </summary>
        Trace = 1,

        /// <summary>
        /// The information
        /// </summary>
        Info = 2,

        /// <summary>
        /// The warn
        /// </summary>
        Warn = 3,

        /// <summary>
        /// The debug
        /// </summary>
        Debug = 4,

        /// <summary>
        /// The error
        /// </summary>
        Error = 5,

        /// <summary>
        /// The fatal
        /// </summary>
        Fatal = 6
    }
}