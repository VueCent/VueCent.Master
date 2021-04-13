// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Base64Helper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace VueCent.Cryptography
{
    /// <summary>
    /// Class Base64Helper.
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// Encrypts the base64.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>System.String.</returns>
        public static string EncryptBase64(this byte[] buffer) => Convert.ToBase64String(buffer);

        /// <summary>
        /// Decrypts the base64.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] DecryptBase64(this string str) => Convert.FromBase64String(str);
    }
}