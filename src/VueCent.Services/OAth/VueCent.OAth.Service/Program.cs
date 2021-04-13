// ***********************************************************************
// Assembly         : VueCent.OAth.Service
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-01-2021
// ***********************************************************************
// <copyright file="Program.cs" company="VueCent.OAth.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Com.Ctrip.Framework.Apollo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace VueCent.OAth.Service
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public static async Task Main(string[] args) => await CreateHostBuilder(args).Build().RunAsync();

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder
                         .UseKestrel()
                         .UseContentRoot(Directory.GetCurrentDirectory())
                         .UseIISIntegration()
                         .UseStartup<Startup>()
                         .ConfigureAppConfiguration((hostingContext, builder) =>
                         {
                             builder.AddJsonFile("appsettings.json", true, true);
                             builder.AddJsonFile("skywalking.json", true, true);
                             builder.AddApollo(builder.Build().GetSection("apollo"))
                               .AddDefault()
                               .AddNamespace("application");
                         });
                 });
    }
}