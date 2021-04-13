// ***********************************************************************
// Assembly         : VueCent.Cache.Redis
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
namespace VueCent.Cache.Redis
{
    /// <summary>
    /// Class Config.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public static string IP { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>The point.</value>
        public static int Point { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>The database.</value>
        public static int DB { get; set; }
    }
}