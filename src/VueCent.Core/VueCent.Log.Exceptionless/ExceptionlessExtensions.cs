// ***********************************************************************
// Assembly         : VueCent.Log.Exceptionless
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ExceptionlessExtensions.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VueCent.Log.Exceptionless
{
    /// <summary>
    /// Class ExceptionlessExtensions.
    /// </summary>
    public static class ExceptionlessExtensions
    {
        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddLog(this IServiceCollection services, IConfiguration configuration)
        {
            Config.Url = configuration["Exceptionless:Url"];
            Config.Key = configuration["Exceptionless:Key"];
            return services;
        }
    }
}