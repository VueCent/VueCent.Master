// ***********************************************************************
// Assembly         : VueCent.Grpc.Consul
// Author           : Administrator
// Created          : 04-13-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="GrpcExtensions.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace VueCent.Grpc.Consul
{
    /// <summary>
    /// Class GrpcExtensions.
    /// </summary>
    public static class GrpcExtensions
    {
        /// <summary>
        /// Uses the consul.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseConsul(this IApplicationBuilder builder, IConfiguration configuration)
        {
            new GrpcHelper()
                .Set(new Config()
                {
                    Name = configuration["Service:Name"],
                    Host = configuration["Service:Host"]
                });
            return builder;
        }
    }
}