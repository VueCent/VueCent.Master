// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="MD5Helper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Cryptography;
using System.Text;
using VueCent.Core;

namespace VueCent.Cryptography
{
    /// <summary>
    /// Class MD5Helper.
    /// </summary>
    public static class MD5Helper
    {
        /// <summary>
        /// Encrypts the m d5.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string EncryptMD5(this string str) => str.EncryptMD5(Encoding.Default);

        /// <summary>
        /// Encrypts the m d5.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptMD5(this string str, Encoding encoding)
        {
            var buffer = str.StringToByte(encoding);
            var provider = new MD5CryptoServiceProvider();
            var hash = provider.ComputeHash(buffer);

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}