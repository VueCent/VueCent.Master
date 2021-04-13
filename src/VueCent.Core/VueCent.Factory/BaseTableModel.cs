// ***********************************************************************
// Assembly         : VueCent.Factory
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
using System.Threading.Tasks;
using System.Xml;
using VueCent.Core;

namespace VueCent.Factory
{
    /// <summary>
    /// Class BaseTableModel.
    /// Implements the <see cref="VueCent.Factory.IBaseTableModel{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Factory.IBaseTableModel{T}" />
    public abstract class BaseTableModel<T> : IBaseTableModel<T>
         where T : class, new()
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public abstract string Code { get; set; }

        /// <summary>
        /// Gets or sets the remark1.
        /// </summary>
        /// <value>The remark1.</value>
        public abstract string Remark1 { get; set; }

        /// <summary>
        /// Gets or sets the remark2.
        /// </summary>
        /// <value>The remark2.</value>
        public abstract string Remark2 { get; set; }

        /// <summary>
        /// Gets or sets the remark3.
        /// </summary>
        /// <value>The remark3.</value>
        public abstract string Remark3 { get; set; }

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> ToJson() => await Task.Run(() => { return JsonHelper.ToJson(this); });

        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> ToModel(string json) => await Task.Run(() => { return JsonHelper.DeJson<T>(json); });

        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> ToModel(XmlDocument xml) => await Task.Run(() => { return XmlHelper.DeXml<T>(xml.ToString()); });

        /// <summary>
        /// Converts to xml.
        /// </summary>
        /// <returns>Task&lt;XmlDocument&gt;.</returns>
        public virtual async Task<XmlDocument> ToXml() => await Task.Run(() => { return XmlHelper.ToXml(this); });
    }
}