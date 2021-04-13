// ***********************************************************************
// Assembly         : VueCent.Log
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ILog.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Log
{
    /// <summary>
    /// Interface ILog
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Log<T>(T t);

        /// <summary>
        /// Logs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="level">The level.</param>
        void Log<T>(T t, Level level);

        /// <summary>
        /// Traces the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Trace<T>(T t);

        /// <summary>
        /// Informations the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Info<T>(T t);

        /// <summary>
        /// Debugs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Debug<T>(T t);

        /// <summary>
        /// Warns the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Warn<T>(T t);

        /// <summary>
        /// Errors the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Error<T>(T t);

        /// <summary>
        /// Fatals the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Fatal<T>(T t);
    }
}