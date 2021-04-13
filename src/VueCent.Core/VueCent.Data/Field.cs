// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Field.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Data
{
    /// <summary>
    /// Class Field. This class cannot be inherited.
    /// </summary>
    public sealed class Field
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName => Name.Replace(@"\r\n", "");

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type => DataType.Replace("varchar", "string")
            .Replace("nvarchar", "string")
            .Replace("sql_variant", "string")
            .Replace("text", "string")
            .Replace("char", "string")
            .Replace("ntext", "string")
            .Replace("hierarchyid", "string")
            .Replace("bit", "bool")
            .Replace("datetime", "DateTime")
            .Replace("datetime2", "DateTime")
            .Replace("date", "DateTime")
            .Replace("time", "DateTime")
            .Replace("smalldatetime", "DateTime")
            .Replace("DateTimestamp", "DateTime")
            .Replace("tinyint", "byte")
            .Replace("bigint", "long")
            .Replace("longstring", "long")
            .Replace("single", "decimal")
            .Replace("money", "decimal")
            .Replace("numeric", "decimal")
            .Replace("smallmoney", "decimal")
            .Replace("float", "decimal")
            .Replace("real", "float")
            .Replace("smallint", "short")
            .Replace("uniqueidentifier", "Guid")
            .Replace("smallmoney", "decimal");

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        public string DataType { get; set; }

        /// <summary>
        /// Gets the type of the column data.
        /// </summary>
        /// <value>The type of the column data.</value>
        public string ColumnDataType => MaxLength <= 0 ? DataType : $"{DataType}({MaxLength})";

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public long MaxLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [null able].
        /// </summary>
        /// <value><c>true</c> if [null able]; otherwise, <c>false</c>.</value>
        public bool NullAble { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Field" /> is unique.
        /// </summary>
        /// <value><c>true</c> if unique; otherwise, <c>false</c>.</value>
        public bool Unique { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Field" /> is index.
        /// </summary>
        /// <value><c>true</c> if index; otherwise, <c>false</c>.</value>
        public bool Index { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>The default.</value>
        public string Default { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        /// <value>The remark.</value>
        public string Remark { get; set; }
    }
}