// ***********************************************************************
// Assembly         : VueCent.Cache.Redis
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="RedisExtensions.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VueCent.Core;

namespace VueCent.Cache.Redis
{
    /// <summary>
    /// Class RedisExtensions.
    /// </summary>
    public static class RedisExtensions
    {
        /// <summary>
        /// Adds the cache.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            Config.IP = configuration["Redis:IP"];
            Config.Point = configuration["Redis:Point"].ToString().GetInt();
            return services;
        }
    }
}