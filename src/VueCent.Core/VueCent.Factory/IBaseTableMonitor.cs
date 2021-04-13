// ***********************************************************************
// Assembly         : VueCent.Factory
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IBaseTableMonitor.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using VueCent.Data;

namespace VueCent.Factory
{
    /// <summary>
    /// Interface IBaseTableMonitor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseTableMonitor<T>
        where T : BaseTableModel<T>, new()
    {
        /// <summary>
        /// Befores the add.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> BeforeAdd(IEnumerable<T> models, BaseMessage msg);

        /// <summary>
        /// Afters the add.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        Task AfterAdd(IEnumerable<T> models);

        /// <summary>
        /// Befores the update.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> BeforeUpdate(IEnumerable<T> models, BaseMessage msg);

        /// <summary>
        /// Afters the update.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        Task AfterUpdate(IEnumerable<T> models);

        /// <summary>
        /// Befores the delete.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> BeforeDelete(IEnumerable<T> models, BaseMessage msg);

        /// <summary>
        /// Afters the delete.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        Task AfterDelete(IEnumerable<T> models);
    }
}