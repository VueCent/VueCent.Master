// ***********************************************************************
// Assembly         : VueCent.Factory.SqlSuagr
// Author           : Administrator
// Created          : 04-01-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="BaseTableDAL.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VueCent.Factory.SqlSuagr
{
    /// <summary>
    /// Class BaseTableDAL.
    /// Implements the <see cref="VueCent.Factory.IBaseTableDAL{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Factory.IBaseTableDAL{T}" />
    public abstract class BaseTableDAL<T> : IBaseTableDAL<T>
          where T : BaseTableModel<T>, new()
    {
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>The client.</value>
        public SqlSugarClient Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTableDAL{T}" /> class.
        /// </summary>
        public BaseTableDAL()
        {
            Client = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.Master,
                SlaveConnectionConfigs = Config.Slave.Select(x => new SlaveConnectionConfig() { ConnectionString = x }).ToList(),
                DbType = Config.DbType,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });

            Client.Aop.OnLogExecuted = (sql, pars) =>
            {
                foreach (var p in pars)
                {
                    if (p.DbType == System.Data.DbType.Int16
                        || p.DbType == System.Data.DbType.Int32
                        || p.DbType == System.Data.DbType.Int64
                        || p.DbType == System.Data.DbType.Decimal
                        || p.DbType == System.Data.DbType.Double
                        || p.DbType == System.Data.DbType.Single
                        || p.DbType == System.Data.DbType.UInt16
                        || p.DbType == System.Data.DbType.UInt32
                        || p.DbType == System.Data.DbType.UInt64
                        || p.DbType == System.Data.DbType.VarNumeric)
                    {
                        sql = sql.Replace(p.ParameterName, p.Value == null ? "" : p.Value.ToString());
                    }
                    else
                    {
                        sql = sql.Replace(p.ParameterName, $"'{(p.Value ?? "")}'");
                    }
                }
                var log = $"\r\nsql : 执行本次SQL消耗 {Client.Ado.SqlExecutionTime.TotalMilliseconds} 毫秒,执行 SQL 内容如下:\r\n{sql};\n";
                Console.WriteLine(log);
            };
        }

        /// <summary>
        /// Adds the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Add(IEnumerable<T> models) => await Client.Insertable<T>(models).ExecuteCommandAsync() > 0;

        /// <summary>
        /// Adds the return entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> AddReturnEntity(T model) => await Client.Insertable(model).ExecuteReturnEntityAsync();

        /// <summary>
        /// Adds the return identifier.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> AddReturnId(T model) => await Client.Insertable(model).ExecuteReturnIdentityAsync();

        /// <summary>
        /// Updates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Update(IEnumerable<T> models) => await Client.Updateable<T>(models).ExecuteCommandAsync() > 0;

        /// <summary>
        /// Deletes the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Delete(IEnumerable<T> models) => await Client.Deleteable<T>(models).ExecuteCommandAsync() > 0;

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <param name="isAsc">The is asc.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, BaseOrderByType isAsc)
            => await Client.Queryable<T>()
            .WhereIF(where != null, where)
            .OrderByIF(order != null, order, GetOrderByType(isAsc))
            .ToListAsync();

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> Count(Expression<Func<T, bool>> where)
            => await Client.Queryable<T>()
            .WhereIF(where != null, where)
            .CountAsync();

        /// <summary>
        /// Pages the specified offset.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="where">The where.</param>
        /// <param name="order">The order.</param>
        /// <param name="isAsc">The is asc.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> Page(int offset, int limit, Expression<Func<T, bool>> where, Expression<Func<T, object>> order, BaseOrderByType isAsc)
            => await Client.Queryable<T>()
            .WhereIF(where != null, where)
            .OrderByIF(order != null, order, GetOrderByType(isAsc))
            .ToPageListAsync(offset, limit);

        private static OrderByType GetOrderByType(BaseOrderByType order)
        {
            return order switch
            {
                BaseOrderByType.Asc => OrderByType.Asc,
                BaseOrderByType.Desc => OrderByType.Desc,
                _ => OrderByType.Asc,
            };
        }
    }
}