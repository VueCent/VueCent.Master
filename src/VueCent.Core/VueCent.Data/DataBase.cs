// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="DataBase.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace VueCent.Data
{
    /// <summary>
    /// Class Database. This class cannot be inherited.
    /// </summary>
    public sealed class Database
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tables.
        /// </summary>
        /// <value>The tables.</value>
        public List<Table> Tables { get; set; } = new List<Table>();

        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        /// <value>The views.</value>
        public List<View> Views { get; set; } = new List<View>();
    }
}