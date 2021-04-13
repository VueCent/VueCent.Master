// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="DESHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Security.Cryptography;
using System.Text;
using VueCent.Core;

namespace VueCent.Cryptography
{
    /// <summary>
    /// Class DESHelper.
    /// </summary>
    public static class DESHelper
    {
        /// <summary>
        /// Encrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string EncryptDES(this string str, string key) => str.EncryptDES(key, Encoding.UTF8, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptDES(this string str, string key, Encoding encoding) => str.EncryptDES(key, encoding, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>System.String.</returns>
        public static string EncryptDES(this string str, string key, Encoding encoding, CipherMode mode) => str.EncryptDES(key, encoding, mode, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptDES(this string str, string key, Encoding encoding, CipherMode mode, PaddingMode padding)
        {
            var keyBuffer = key.StringToByte(encoding);
            var iv = keyBuffer;
            var strBuffter = str.StringToByte(encoding);

            var provider = new DESCryptoServiceProvider
            {
                Mode = mode,
                Padding = padding
            };
            var result = new MemoryStream();
            var copy = new CryptoStream(result, provider.CreateEncryptor(keyBuffer, iv), CryptoStreamMode.Write);
            copy.Write(strBuffter, 0, strBuffter.Length);
            copy.FlushFinalBlock();

            return result.ToArray().EncryptBase64();
        }

        /// <summary>
        /// Decrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string DecryptDES(this string str, string key) => str.DecryptDES(key, Encoding.UTF8, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string DecryptDES(this string str, string key, Encoding encoding) => str.DecryptDES(key, encoding, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>System.String.</returns>
        public static string DecryptDES(this string str, string key, Encoding encoding, CipherMode mode) => str.DecryptDES(key, encoding, mode, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the DES.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>System.String.</returns>
        public static string DecryptDES(this string str, string key, Encoding encoding, CipherMode mode, PaddingMode padding)
        {
            var keyBuffer = key.StringToByte(encoding);
            var iv = keyBuffer;
            var strBuffter = str.DecryptBase64();

            var provider = new DESCryptoServiceProvider
            {
                Mode = mode,
                Padding = padding
            };
            var result = new MemoryStream();
            var copy = new CryptoStream(result, provider.CreateDecryptor(keyBuffer, iv), CryptoStreamMode.Write);
            copy.Write(strBuffter, 0, strBuffter.Length);
            copy.FlushFinalBlock();

            return result.ToArray().ByteToString(encoding);
        }
    }
}