// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="SHAHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Security.Cryptography;
using System.Text;
using VueCent.Core;

namespace VueCent.Cryptography
{
    /// <summary>
    /// Class SHAHelper.
    /// </summary>
    public static class SHAHelper
    {
        /// <summary>
        /// Encrypts the sha.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string EncryptSHA(this string str) => str.EncryptSHA(Encoding.Default);

        /// <summary>
        /// Encrypts the sha.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptSHA(this string str, Encoding encoding)
        {
            var buffer = str.StringToByte(encoding);
            var provider = new SHA1CryptoServiceProvider();
            buffer = provider.ComputeHash(buffer);
            var result = new StringBuilder();
            foreach (var temp in buffer)
            {
                result.AppendFormat("{0:x2}", temp);
            }

            return result.ToString();
        }
    }
}