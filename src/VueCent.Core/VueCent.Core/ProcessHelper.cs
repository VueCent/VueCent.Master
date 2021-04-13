// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ProcessHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;

namespace VueCent.Core
{
    /// <summary>
    /// Class ProcessHelper. This class cannot be inherited.
    /// </summary>
    public sealed class ProcessHelper
    {
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>System.String.</returns>
        public static string Execute(string cmd) => Execute(cmd, string.Empty);

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>System.String.</returns>
        public static string Execute(string cmd, string arguments)
        {
            var p = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = cmd,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardError = false,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                ErrorDialog = false,
                WorkingDirectory = Environment.CurrentDirectory,
                Verb = "runas"
            };
            if (!string.IsNullOrWhiteSpace(arguments))
            {
                startInfo.Arguments = arguments;
            }
            p.StartInfo = startInfo;

            p.Start();
            var i = 1;
            while (!p.HasExited)
            {
                i++;
                p.WaitForExit(500);
                if (i == 5)
                {
                    p.Kill();
                    return string.Empty;
                }
            }
            var result = p.StandardOutput.ReadToEnd();
            p.Close();
            return result;
        }
    }
}