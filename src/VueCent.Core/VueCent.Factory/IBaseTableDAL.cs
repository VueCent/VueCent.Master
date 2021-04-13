// ***********************************************************************
// Assembly         : VueCent.Factory
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IBaseTableDAL.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VueCent.Factory
{
    /// <summary>
    /// Interface IBaseTableDAL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseTableDAL<T>
        where T : BaseTableModel<T>, new()
    {
        /// <summary>
        /// Adds the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Add(IEnumerable<T> models);

        /// <summary>
        /// Adds the return entity.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> AddReturnEntity(T models);

        /// <summary>
        /// Adds the return identifier.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> AddReturnId(T models);

        /// <summary>
        /// Updates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Update(IEnumerable<T> models);

        /// <summary>
        /// Deletes the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(IEnumerable<T> models);

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <param name="isAsc">The is asc.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, BaseOrderByType isAsc);

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> Count(Expression<Func<T, bool>> where);

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <param name="isAsc">The is asc.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> Page(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order, BaseOrderByType isAsc);
    }
}