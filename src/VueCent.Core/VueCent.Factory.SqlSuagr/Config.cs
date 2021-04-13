// ***********************************************************************
// Assembly         : VueCent.Factory.SqlSuagr
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Config.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using SqlSugar;
using System.Collections.Generic;

namespace VueCent.Factory.SqlSuagr
{
    /// <summary>
    /// Class Config.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Gets or sets the type of the database.
        /// </summary>
        /// <value>The type of the database.</value>
        public static DbType DbType { get; set; }

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>The master.</value>
        public static string Master { get; set; }

        /// <summary>
        /// Gets or sets the slave.
        /// </summary>
        /// <value>The slave.</value>
        public static List<string> Slave { get; set; }
    }
}