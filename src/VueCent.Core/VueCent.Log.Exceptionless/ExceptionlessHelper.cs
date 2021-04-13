// ***********************************************************************
// Assembly         : VueCent.Log.Exceptionless
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ExceptionlessHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptionless;
using Exceptionless.Logging;
using VueCent.Core;

namespace VueCent.Log.Exceptionless
{
    /// <summary>
    /// Class ExceptionlessHelper.
    /// Implements the <see cref="VueCent.Log.ILog" />
    /// </summary>
    /// <seealso cref="VueCent.Log.ILog" />
    public class ExceptionlessHelper : ILog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionlessHelper"/> class.
        /// </summary>
        public ExceptionlessHelper()
        {
            ExceptionlessClient.Default.Configuration.ServerUrl = Config.Url;
            ExceptionlessClient.Default.Configuration.ApiKey = Config.Key;
        }

        /// <summary>
        /// Logs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Log<T>(T t) => Log(t, Level.Info);

        /// <summary>
        /// Logs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="level">The level.</param>
        public void Log<T>(T t, Level level)
        {
            var logLevel = level switch
            {
                Level.Trace => LogLevel.Trace,
                Level.Info => LogLevel.Info,
                Level.Warn => LogLevel.Warn,
                Level.Debug => LogLevel.Debug,
                Level.Error => LogLevel.Error,
                Level.Fatal => LogLevel.Fatal,
                _ => LogLevel.Trace
            };

            ExceptionlessClient.Default.SubmitLog(t.ToJson(), logLevel);
        }

        /// <summary>
        /// Debugs the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Debug<T>(T t) => Log(t, Level.Debug);

        /// <summary>
        /// Errors the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Error<T>(T t) => Log(t, Level.Error);

        /// <summary>
        /// Informations the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Info<T>(T t) => Log(t, Level.Info);

        /// <summary>
        /// Traces the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Trace<T>(T t) => Log(t, Level.Trace);

        /// <summary>
        /// Warns the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Warn<T>(T t) => Log(t, Level.Warn);

        /// <summary>
        /// Fatals the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Fatal<T>(T t) => Log(t, Level.Trace);
    }
}