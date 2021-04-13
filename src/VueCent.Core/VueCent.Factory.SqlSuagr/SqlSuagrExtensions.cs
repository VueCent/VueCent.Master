// ***********************************************************************
// Assembly         : VueCent.Factory.SqlSuagr
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="SqlSuagrExtensions.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System.Collections.Generic;
using System.Linq;

namespace VueCent.Factory.SqlSuagr
{
    /// <summary>
    /// Class SqlSuagrExtensions.
    /// </summary>
    public static class SqlSuagrExtensions
    {
        /// <summary>
        /// Adds the factory.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddFactory(this IServiceCollection services, IConfiguration configuration)
        {
            Config.DbType = GetDbType(configuration["Database:Type"]);
            Config.Master = configuration["Database:Master"];
            Config.Slave = new List<string>();

            var slave = configuration["Database:Slaves"].ToString().Split(",", System.StringSplitOptions.RemoveEmptyEntries).ToList();
            slave.ForEach(value =>
            {
                Config.Slave.Add(value);
            });
            return services;
        }

        /// <summary>
        /// Gets the type of the database.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>SqlSugar.DbType.</returns>
        private static DbType GetDbType(string type) => type switch
        {
            "MySql" => DbType.MySql,
            "SqlServer" => DbType.SqlServer,
            "Sqlite" => DbType.Sqlite,
            "Oracle" => DbType.Oracle,
            "PostgreSQL" => DbType.PostgreSQL,
            "Dm" => DbType.Dm,
            "Kdbndp" => DbType.Kdbndp,
            _ => DbType.SqlServer,
        };
    }
}