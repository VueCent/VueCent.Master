// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="XmlHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace VueCent.Core
{
    /// <summary>
    /// Class XmlHelper.
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Converts to xml.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Xml.XmlDocument.</returns>
        public static XmlDocument ToXml(this object obj)
        {
            if (obj != null)
            {
                using var writer = new StringWriter();
                new XmlSerializer(obj.GetType()).Serialize(writer, obj);

                var document = new XmlDocument();
                document.LoadXml(writer.ToString());
                return document;
            }
            return null;
        }

        /// <summary>
        /// Des the XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns>T.</returns>
        public static T DeXml<T>(string xml)
        {
            if (!string.IsNullOrWhiteSpace(xml))
            {
                using var reader = new StringReader(xml);
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
            return default;
        }
    }
}