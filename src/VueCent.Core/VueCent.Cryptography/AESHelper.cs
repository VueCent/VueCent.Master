// ***********************************************************************
// Assembly         : VueCent.Cryptography
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="AESHelper.cs" company="VueCent">
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
    /// Class AESHelper.
    /// </summary>
    public static class AESHelper
    {
        /// <summary>
        /// Encrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string EncryptAES(this string str, string key) => str.EncryptAES(key, Encoding.Default, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptAES(this string str, string key, Encoding encoding) => str.EncryptAES(key, encoding, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>System.String.</returns>
        public static string EncryptAES(this string str, string key, Encoding encoding, CipherMode mode) => str.EncryptAES(key, encoding, mode, PaddingMode.PKCS7);

        /// <summary>
        /// Encrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>System.String.</returns>
        public static string EncryptAES(this string str, string key, Encoding encoding, CipherMode mode, PaddingMode padding)
        {
            var keyBuffer = encoding.GetBytes(key);
            var strBuffer = encoding.GetBytes(str);

            var provider = new RijndaelManaged
            {
                Key = keyBuffer,
                Mode = mode,
                Padding = padding
            };

            var from = provider.CreateEncryptor();
            var result = from.TransformFinalBlock(strBuffer, 0, strBuffer.Length);

            return result.EncryptBase64();
        }

        /// <summary>
        /// Decrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string DecryptAES(this string str, string key) => str.DecryptAES(key, Encoding.Default, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        public static string DecryptAES(this string str, string key, Encoding encoding) => str.DecryptAES(key, encoding, CipherMode.ECB, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>System.String.</returns>
        public static string DecryptAES(this string str, string key, Encoding encoding, CipherMode mode) => str.DecryptAES(key, encoding, mode, PaddingMode.PKCS7);

        /// <summary>
        /// Decrypts the aes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>System.String.</returns>
        public static string DecryptAES(this string str, string key, Encoding encoding, CipherMode mode, PaddingMode padding)
        {
            var keyBuffer = key.StringToByte(encoding);
            var str64 = str.DecryptBase64();

            var provider = new RijndaelManaged
            {
                Key = keyBuffer,
                Mode = mode,
                Padding = padding
            };

            var from = provider.CreateDecryptor();
            var result = from.TransformFinalBlock(str64, 0, str64.Length);

            return result.ByteToString(encoding);
        }
    }
}