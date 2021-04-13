// ***********************************************************************
// Assembly         : VueCent.Factory
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IBaseTableModel.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using System.Xml;

namespace VueCent.Factory
{
    /// <summary>
    /// Interface IBaseTableModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseTableModel<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the remark1.
        /// </summary>
        /// <value>The remark1.</value>
        string Remark1 { get; set; }

        /// <summary>
        /// Gets or sets the remark2.
        /// </summary>
        /// <value>The remark2.</value>
        string Remark2 { get; set; }

        /// <summary>
        /// Gets or sets the remark3.
        /// </summary>
        /// <value>The remark3.</value>
        string Remark3 { get; set; }

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> ToJson();

        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> ToModel(string json);

        /// <summary>
        /// Converts to model.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> ToModel(XmlDocument xml);

        /// <summary>
        /// Converts to xml.
        /// </summary>
        /// <returns>Task&lt;XmlDocument&gt;.</returns>
        Task<XmlDocument> ToXml();
    }
}