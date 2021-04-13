// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="RSAHelper.cs" company="VueCent">
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
    /// Class RSAHelper.
    /// </summary>
    public static class RSAHelper
    {
        /// <summary>
        /// Encrypts the RSA.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string EncryptRSA(this string str, out string key) => str.EncryptRSA(out key, Encoding.Default);

        /// <summary>
        /// Encrypts the RSA.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptRSA(this string str, out string key, Encoding encoding)
        {
            var buffer = str.StringToByte(encoding);
            var provider = new RSACryptoServiceProvider();
            var result = provider.Encrypt(buffer, false);
            key = provider.ExportCspBlob(true).EncryptBase64();
            return result.EncryptBase64();
        }

        /// <summary>
        /// Decrypts the RSA.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string DecryptRSA(this string str, string key) => str.DecryptRSA(key, Encoding.Default);

        /// <summary>
        /// Decrypts the RSA.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string DecryptRSA(this string str, string key, Encoding encoding)
        {
            var strBuffer = str.DecryptBase64();
            var keyBuffer = key.DecryptBase64();
            var provider = new RSACryptoServiceProvider();
            provider.ImportCspBlob(keyBuffer);
            var result = provider.Decrypt(strBuffer, false);
            return result.ByteToString(encoding);
        }
    }
}