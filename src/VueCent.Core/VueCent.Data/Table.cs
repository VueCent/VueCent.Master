// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Table.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using VueCent.Core;

namespace VueCent.Data
{
    /// <summary>
    /// Class Table. This class cannot be inherited.
    /// </summary>
    public sealed class Table
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the name of the dispaly.
        /// </summary>
        /// <value>The name of the dispaly.</value>
        public string DispalyName => Name.ToCamelCase();

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        /// <value>The remark.</value>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>The fields.</value>
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}