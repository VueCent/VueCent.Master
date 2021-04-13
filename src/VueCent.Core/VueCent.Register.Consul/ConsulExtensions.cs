// ***********************************************************************
// Assembly         : VueCent.Register.Consul
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ConsulExtensions.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using VueCent.Core;

namespace VueCent.Register.Consul
{
    /// <summary>
    /// Class ConsulExtensions.
    /// </summary>
    public static class ConsulExtensions
    {
        /// <summary>
        /// Uses the consul.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseConsul(this IApplicationBuilder builder, IConfiguration configuration)
        {
            ConsulHelper.BaseUrl = configuration["Consul"];
            new ConsulHelper()
                .Set(new Config()
                {
                    Name = configuration["Service:Name"],
                    Host = configuration["Service:Host"],
                    Interval = configuration["Service:Interval"].ToString().GetInt(),
                    Timeout = configuration["Service:Timeout"].ToString().GetInt(),
                    DeregisterCriticalServiceAfter = configuration["Service:DeregisterCriticalServiceAfter"].ToString().GetInt(),
                    IP = configuration["IP"],
                    Port = configuration["Port"].ToString().GetInt(),
                });

            return builder;
        }
    }
}