// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="JsonHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VueCent.Core
{
    /// <summary>
    /// Class JsonHelper.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// The settings
        /// </summary>
        private static readonly JsonSerializerSettings settings;

        /// <summary>
        /// Initializes static members of the <see cref="JsonHelper" /> class.
        /// </summary>
        static JsonHelper()
        {
            var datetimeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy/MM/dd HH:mm:ss"
            };
            settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            settings.Converters.Add(datetimeConverter);
        }

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToJson(this object obj) => obj == null ? string.Empty : JsonConvert.SerializeObject(obj, Formatting.None, settings);

        /// <summary>
        /// Des the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns>T.</returns>
        public static T DeJson<T>(string json) => string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject<T>(json, settings);
    }
}