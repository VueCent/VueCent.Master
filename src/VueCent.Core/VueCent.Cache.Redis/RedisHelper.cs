// ***********************************************************************
// Assembly         : VueCent.Cache.Redis
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="RedisHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using VueCent.Core;

namespace VueCent.Cache.Redis
{
    /// <summary>
    /// Class RedisHelper. This class cannot be inherited.
    /// Implements the <see cref="VueCent.Cache.ICacheHelper" />
    /// </summary>
    /// <seealso cref="VueCent.Cache.ICacheHelper" />
    public sealed class RedisHelper : ICacheHelper
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly IDatabase client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisHelper" /> class.
        /// </summary>
        /// <param name="db">The database.</param>
        public RedisHelper(int db = 0)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect($"{Config.IP}:{Config.Point}");
            client = connectionMultiplexer.GetDatabase(db);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public T Get<T>(string key)
        {
            if (HasKey(key))
            {
                var json = client.StringGet(key);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonHelper.DeJson<T>(json);
                }
            }
            return default;
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Set<T>(string key, T value) => client.StringSet(key, value.ToJson());

        /// <summary>
        /// Sets the hash.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetHash<T>(string key, string field, T value) => client.HashSet(key, field, value.ToJson());

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="field">The field.</param>
        /// <returns>T.</returns>
        public T GetHash<T>(string key, string field)
        {
            if (HasHash(key, field))
            {
                var json = client.HashGet(key, field);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonHelper.DeJson<T>(json);
                }
            }
            return default;
        }

        /// <summary>
        /// Determines whether the specified key has hash.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="filed">The filed.</param>
        /// <returns><c>true</c> if the specified key has hash; otherwise, <c>false</c>.</returns>
        public bool HasHash(string key, string filed) => client.HashExists(key, filed);

        /// <summary>
        /// Removes the hash.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="field">The field.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveHash(string key, string field) => client.HashDelete(key, field);

        /// <summary>
        /// Lefts the set list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LeftSetList<T>(string key, T value) => client.ListLeftPush(key, value.ToJson()) > 0;

        /// <summary>
        /// Rights the set list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RightSetList<T>(string key, T value) => client.ListRightPush(key, value.ToJson()) > 0;

        /// <summary>
        /// Removes the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveList<T>(string key, T value) => client.ListRemove(key, value.ToJson()) > 0;

        /// <summary>
        /// Lefts the remove list.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LeftRemoveList(string key) => string.IsNullOrWhiteSpace(client.ListLeftPop(key));

        /// <summary>
        /// Rights the remove list.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RightRemoveList(string key) => string.IsNullOrWhiteSpace(client.ListRightPop(key));

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="index">The index.</param>
        /// <returns>T.</returns>
        public T GetList<T>(string key, int index)
        {
            if (HasKey(key))
            {
                var json = client.ListGetByIndex(key, index);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonHelper.DeJson<T>(json);
                }
            }
            return default;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> GetList<T>(string key, int start, int end)
        {
            var list = new List<T>();
            if (HasKey(key))
            {
                foreach (string value in client.ListRange(key, start, end).ToList())
                {
                    list.Add(JsonHelper.DeJson<T>(value));
                }
            }
            return list;
        }

        /// <summary>
        /// Sets the sorted set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="score">The score.</param>
        public void SetSortedSet<T>(string key, T value, double score) => client.SortedSetAdd(key, value.ToJson(), score);

        /// <summary>
        /// Gets the sorted set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="strart">The strart.</param>
        /// <param name="stop">The stop.</param>
        /// <param name="order">The order.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> GetSortedSet<T>(string key, long strart = 0, long stop = int.MaxValue, Order order = Order.Descending)
        {
            var list = new List<T>();
            if (HasKey(key))
            {
                foreach (string value in client.SortedSetRangeByRank(key, strart, stop, order))
                {
                    list.Add(JsonHelper.DeJson<T>(value));
                }
            }
            return list;
        }

        /// <summary>
        /// Deletes the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteKey(string key) => client.KeyDelete(key);

        /// <summary>
        /// Determines whether the specified key has key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key has key; otherwise, <c>false</c>.</returns>
        public bool HasKey(string key) => client.KeyExists(key);

        /// <summary>
        /// Res the name key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="newKey">The new key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReNameKey(string key, string newKey) => client.KeyRename(key, newKey);

        /// <summary>
        /// Sets the key expire.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="expireTime">The expire time.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetKeyExpire(string key, TimeSpan expireTime) => client.KeyExpire(key, expireTime);
    }
}