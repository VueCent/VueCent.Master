// ***********************************************************************
// Assembly         : VueCent.Factory
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IBaseTableBLL.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;
using VueCent.Data;

namespace VueCent.Factory
{
    /// <summary>
    /// Interface IBaseTableBLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseTableBLL<T>
        where T : BaseTableModel<T>, new()
    {
        /// <summary>
        /// Gets the dal.
        /// </summary>
        /// <value>The dal.</value>
        IBaseTableDAL<T> DAL { get; }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Add(T model);

        /// <summary>
        /// Adds the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Add(string json);

        /// <summary>
        /// Adds the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Add(XmlDocument xml);

        /// <summary>
        /// Adds the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Add(IEnumerable<T> models);

        /// <summary>
        /// Adds the return entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> AddReturnEntity(T model);

        /// <summary>
        /// Adds the return identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> AddReturnId(T model);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Update(T model);

        /// <summary>
        /// Updates the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Update(string json);

        /// <summary>
        /// Updates the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Update(XmlDocument xml);

        /// <summary>
        /// Updates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Update(IEnumerable<T> models);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(int key);

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(T model);

        /// <summary>
        /// Deletes the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(string json);

        /// <summary>
        /// Deletes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(XmlDocument xml);

        /// <summary>
        /// Deletes the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> Delete(IEnumerable<T> models);

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> Get();

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> Get(int key);

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Gets the asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> GetAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Gets the desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        Task<IEnumerable<T>> GetDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Firsts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> First(Expression<Func<T, bool>> where);

        /// <summary>
        /// Firsts the asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FirstAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Firsts the desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FirstDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetJson();

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetJson(int key);

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetJson(Expression<Func<T, bool>> where);

        /// <summary>
        /// Gets the json asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetJsonAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Gets the json desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetJsonDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Pages this instance.
        /// </summary>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        Task<PageMessage<T>> Page();

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        Task<PageMessage<T>> Page(int offset, int limit);

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        Task<PageMessage<T>> Page(int offset, int limit, Expression<Func<T, bool>> where);

        /// <summary>
        /// Pages the asc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        Task<PageMessage<T>> PageAsc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Pages the desc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        Task<PageMessage<T>> PageDesc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PageJson();

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PageJson(int offset, int limit);

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PageJson(int offset, int limit, Expression<Func<T, bool>> where);

        /// <summary>
        /// Pages the json asc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PageJsonAsc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order);

        /// <summary>
        /// Pages the json desc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PageJsonDesc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order);
    }
}