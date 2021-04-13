// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="StringHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace VueCent.Core
{
    /// <summary>
    /// Class StringHelper.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Bytes to string.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>System.String.</returns>
        public static string ByteToString(this byte[] buffer) => ByteToString(buffer, Encoding.Default);

        /// <summary>
        /// Bytes to string.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string ByteToString(this byte[] buffer, Encoding encoding) => encoding.GetString(buffer);

        /// <summary>
        /// Bytes to stream.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>Stream.</returns>
        public static Stream ByteToStream(this byte[] buffer) => ByteToStream(buffer, Encoding.Default);

        /// <summary>
        /// Bytes to stream.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Stream.</returns>
        public static Stream ByteToStream(this byte[] buffer, Encoding encoding) => buffer.ByteToString(encoding).StringToStream(encoding);

        /// <summary>
        /// Strings to byte.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] StringToByte(this string str) => StringToByte(str, Encoding.Default);

        /// <summary>
        /// Strings to byte.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] StringToByte(this string str, Encoding encoding) => encoding.GetBytes(str);

        /// <summary>
        /// Strings to stream.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>Stream.</returns>
        public static Stream StringToStream(this string str) => StringToStream(str, Encoding.Default);

        /// <summary>
        /// Strings to stream.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Stream.</returns>
        public static Stream StringToStream(this string str, Encoding encoding) => str.StringToByte(encoding).ByteToStream(encoding);

        /// <summary>
        /// Streams to string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.String.</returns>
        public static string StreamToString(this Stream stream) => StreamToString(stream, Encoding.Default);

        /// <summary>
        /// Streams to string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string StreamToString(this Stream stream, Encoding encoding) => stream.StreamToByte().ByteToString(encoding);

        /// <summary>
        /// Streams to byte.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] StreamToByte(this Stream stream)
        {
            var buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, (int)stream.Length);
            stream.Close();
            return buffer;
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object GetDefault(this Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;

        /// <summary>
        /// Converts to camelcase.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.ToCamelCase("_").ToCamelCase("-").ToCamelCase(".");
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts to camelcase.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="split">The split.</param>
        /// <returns>System.String.</returns>
        private static string ToCamelCase(this string str, string split)
        {
            if (!string.IsNullOrWhiteSpace(str) && !string.IsNullOrWhiteSpace(split))
            {
                var array = str.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();
                var sb = new StringBuilder();
                array.ForEach(x =>
                {
                    if (x.Length == 1)
                    {
                        sb.Append(x.ToUpper());
                    }
                    else
                    {
                        sb.Append(x[0].ToString().ToUpper() + x[1..]);
                    }
                });
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}