// ***********************************************************************
// Assembly         : VueCent.Database.Model
// Author           : Administrator
// Created          : 04-08-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-12-2021
// ***********************************************************************
// <copyright file="SysUserModel.cs" company="VueCent.Database.Model">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using SqlSugar;
using System;
using VueCent.Factory.SqlSuagr;

namespace VueCent.Database.Model
{
    /// <summary>
    /// Class SysUserModel.
    /// Implements the <see cref="VueCent.Factory.SqlSuagr.BaseTableModel{VueCent.Database.Model.SysUserModel}" />
    /// </summary>
    /// <seealso cref="VueCent.Factory.SqlSuagr.BaseTableModel{VueCent.Database.Model.SysUserModel}" />
    [Serializable]
    [SugarTable("US01")]
    public class SysUserModel : BaseTableModel<SysUserModel>
    {
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "TB01")]
        public string Table { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "TB02")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the BLL.
        /// </summary>
        /// <value>The BLL.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "TB03")]
        public string BLL { get; set; }

        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        /// <value>The dal.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "TB04")]
        public string DAL { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SysUserModel"/> is system.
        /// </summary>
        /// <value><c>true</c> if system; otherwise, <c>false</c>.</value>
        [SugarColumn(ColumnDataType = "bit", ColumnName = "TB05")]
        public bool Sys { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        /// <value>The remark.</value>
        [SugarColumn(ColumnDataType = "varchar(max)", ColumnName = "TB06")]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>The sort.</value>
        [SugarColumn(ColumnDataType = "int", ColumnName = "TB07")]
        public int Sort { get; set; }
    }
}