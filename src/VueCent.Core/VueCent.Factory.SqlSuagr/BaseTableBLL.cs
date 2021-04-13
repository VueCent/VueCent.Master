// ***********************************************************************
// Assembly         : VueCent.Factory.SqlSuagr
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="BaseTableBLL.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;
using VueCent.Core;
using VueCent.Data;

namespace VueCent.Factory.SqlSuagr
{
    /// <summary>
    /// Class BaseTableBLL.
    /// Implements the <see cref="VueCent.Factory.IBaseTableBLL{T}" />
    /// Implements the <see cref="VueCent.Factory.IBaseTableMonitor{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Factory.IBaseTableBLL{T}" />
    /// <seealso cref="VueCent.Factory.IBaseTableMonitor{T}" />
    public abstract class BaseTableBLL<T> : IBaseTableBLL<T>, IBaseTableMonitor<T>
        where T : BaseTableModel<T>, new()
    {
        /// <summary>
        /// Gets the dal.
        /// </summary>
        /// <value>The dal.</value>
        public abstract IBaseTableDAL<T> DAL { get; }

        /// <summary>
        /// Afters the add.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        public virtual async Task AfterAdd(IEnumerable<T> models) => await Task.Run(() => { });

        /// <summary>
        /// Befores the add.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> BeforeAdd(IEnumerable<T> models, BaseMessage msg) => await Task.Run(() => { return models; });

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Add(T model) => await Add(new List<T> { model });

        /// <summary>
        /// Adds the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Add(string json) => await Add(await new T().ToModel(json));

        /// <summary>
        /// Adds the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Add(XmlDocument xml) => await Add(await new T().ToModel(xml));

        /// <summary>
        /// Adds the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Add(IEnumerable<T> models)
        {
            var msg = new BaseMessage();
            var _models = await BeforeAdd(models, msg);
            if (msg.Succeed && _models.ToList().Count > 0)
            {
                var flag = await DAL.Add(_models);
                await AfterAdd(_models);
                return flag;
            }
            return false;
        }

        /// <summary>
        /// Adds the return entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> AddReturnEntity(T model)
        {
            var msg = new BaseMessage();
            var _models = await BeforeAdd(new List<T> { model }, msg);
            if (msg.Succeed && _models.ToList().Count > 0)
            {
                var flag = await DAL.AddReturnEntity(model);
                await AfterAdd(_models);
                return flag;
            }
            return null;
        }

        /// <summary>
        /// Adds the return identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public virtual async Task<int> AddReturnId(T model)
        {
            var msg = new BaseMessage();
            var _models = await BeforeAdd(new List<T> { model }, msg);
            if (msg.Succeed && _models.ToList().Count > 0)
            {
                var flag = await DAL.AddReturnId(model);
                await AfterAdd(_models);
                return flag;
            }
            return 0;
        }

        /// <summary>
        /// Afters the update.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        public virtual async Task AfterUpdate(IEnumerable<T> models) => await Task.Run(() => { });

        /// <summary>
        /// Befores the update.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> BeforeUpdate(IEnumerable<T> models, BaseMessage msg) => await Task.Run(() => { return models; });

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Update(T model) => await Update(new List<T> { model });

        /// <summary>
        /// Updates the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Update(string json) => await Update(await new T().ToModel(json));

        /// <summary>
        /// Updates the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Update(XmlDocument xml) => await Update(await new T().ToModel(xml));

        /// <summary>
        /// Updates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Update(IEnumerable<T> models)
        {
            var msg = new BaseMessage();
            var _models = await BeforeUpdate(models, msg);
            if (msg.Succeed && _models.ToList().Count > 0)
            {
                var flag = await DAL.Update(_models);
                await AfterUpdate(_models);
                return flag;
            }
            return false;
        }

        /// <summary>
        /// Afters the delete.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task.</returns>
        public virtual async Task AfterDelete(IEnumerable<T> models) => await Task.Run(() => { });

        /// <summary>
        /// Befores the delete.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> BeforeDelete(IEnumerable<T> models, BaseMessage msg) => await Task.Run(() => { return models; });

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Delete(int key)
        {
            var model = await Get(key);
            if (model != null)
            {
                return await Delete(new List<T>() { model });
            }
            return false;
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Delete(T model) => await Delete(new List<T> { model });

        /// <summary>
        /// Deletes the specified json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Delete(string json) => await Delete(await new T().ToModel(json));

        /// <summary>
        /// Deletes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Delete(XmlDocument xml) => await Delete(await new T().ToModel(xml));

        /// <summary>
        /// Deletes the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public virtual async Task<bool> Delete(IEnumerable<T> models)
        {
            var msg = new BaseMessage();
            var _models = await BeforeDelete(models, msg);
            if (msg.Succeed && _models.ToList().Count > 0)
            {
                var flag = await DAL.Delete(_models);
                await AfterDelete(_models);
                return flag;
            }
            return false;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> Get() => await GetAsc(null, null);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> Get(int key)
        {
            var data = await GetAsc(x => x.Id == key, null);
            return data.FirstOrDefault();
        }

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where) => await GetAsc(where, null);

        /// <summary>
        /// Gets the asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> GetAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
            => await DAL.Get(where, order, BaseOrderByType.Asc);

        /// <summary>
        /// Gets the desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public virtual async Task<IEnumerable<T>> GetDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
            => await DAL.Get(where, order, BaseOrderByType.Desc);

        /// <summary>
        /// Firsts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> First(Expression<Func<T, bool>> where)
        {
            var models = await GetAsc(where, null);
            return models.FirstOrDefault();
        }

        /// <summary>
        /// Firsts the asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> FirstAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var models = await GetAsc(where, order);
            return models.FirstOrDefault();
        }

        /// <summary>
        /// Firsts the desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public virtual async Task<T> FirstDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var models = await GetDesc(where, order);
            return models.FirstOrDefault();
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> GetJson()
        {
            var data = await Get();
            return data.ToJson();
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> GetJson(int key)
        {
            var data = await Get(key);
            return await data.ToJson();
        }

        /// <summary>
        /// Gets the json.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> GetJson(Expression<Func<T, bool>> where)
        {
            var data = await Get(where);
            return data.ToJson();
        }

        /// <summary>
        /// Gets the json asc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> GetJsonAsc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var data = await GetAsc(where, order);
            return data.ToJson();
        }

        /// <summary>
        /// Gets the json desc.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> GetJsonDesc(Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var data = await GetDesc(where, order);
            return data.ToJson();
        }

        /// <summary>
        /// Pages this instance.
        /// </summary>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        public virtual async Task<PageMessage<T>> Page() => await PageAsc(1, 10, null, null);

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        public virtual async Task<PageMessage<T>> Page(int offset, int limit) => await PageAsc(offset, limit, null, null);

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        public virtual async Task<PageMessage<T>> Page(int offset, int limit, Expression<Func<T, bool>> where)
            => await PageAsc(offset, limit, where, null);

        /// <summary>
        /// Pages the asc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        public virtual async Task<PageMessage<T>> PageAsc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
            => new PageMessage<T>()
            {
                Offset = offset,
                Limit = limit,
                Total = await DAL.Count(where),
                Rows = await DAL.Page(1, 10, where, order, BaseOrderByType.Asc)
            };

        /// <summary>
        /// Pages the desc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;PageMessage&lt;T&gt;&gt;.</returns>
        public virtual async Task<PageMessage<T>> PageDesc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
            => new PageMessage<T>()
            {
                Offset = offset,
                Limit = limit,
                Total = await DAL.Count(where),
                Rows = await DAL.Page(1, 10, where, order, BaseOrderByType.Desc)
            };

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> PageJson()
        {
            var data = await Page();
            return data.ToJson();
        }

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> PageJson(int offset, int limit)
        {
            var data = await Page(offset, limit);
            return data.ToJson();
        }

        /// <summary>
        /// Pages the json.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> PageJson(int offset, int limit, Expression<Func<T, bool>> where)
        {
            var data = await Page(offset, limit, where);
            return data.ToJson();
        }

        /// <summary>
        /// Pages the json asc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> PageJsonAsc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var data = await PageAsc(offset, limit, where, order);
            return data.ToJson();
        }

        /// <summary>
        /// Pages the json desc.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public virtual async Task<string> PageJsonDesc(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order)
        {
            var data = await PageDesc(offset, limit, where, order);
            return data.ToJson();
        }
    }
}