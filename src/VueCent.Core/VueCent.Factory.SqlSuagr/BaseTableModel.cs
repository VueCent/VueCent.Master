// ***********************************************************************
// Assembly         : VueCent.Factory.SqlSuagr
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="BaseTableModel.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using SqlSugar;

namespace VueCent.Factory.SqlSuagr
{
    /// <summary>
    /// Class BaseTableModel.
    /// Implements the <see cref="VueCent.Factory.BaseTableModel{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Factory.BaseTableModel{T}" />
    public abstract class BaseTableModel<T> : Factory.BaseTableModel<T>
         where T : class, new()
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnDataType = "int", ColumnName = "VC01")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "VC02")]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "VC03")]
        public override string Code { get; set; }

        /// <summary>
        /// Gets or sets the remark1.
        /// </summary>
        /// <value>The remark1.</value>
        [SugarColumn(ColumnDataType = "varchar(max)", ColumnName = "VC04")]
        public override string Remark1 { get; set; }

        /// <summary>
        /// Gets or sets the remark2.
        /// </summary>
        /// <value>The remark2.</value>
        [SugarColumn(ColumnDataType = "varchar(max)", ColumnName = "VC05")]
        public override string Remark2 { get; set; }

        /// <summary>
        /// Gets or sets the remark3.
        /// </summary>
        /// <value>The remark3.</value>
        [SugarColumn(ColumnDataType = "varchar(max)", ColumnName = "VC06")]
        public override string Remark3 { get; set; }
    }
}