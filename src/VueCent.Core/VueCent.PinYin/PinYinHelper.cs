// ***********************************************************************
// Assembly         : VueCent.PinYin
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="PinYinHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text;

namespace VueCent.PinYin
{
    /// <summary>
    /// Class PinYinHelper.
    /// </summary>
    public static class PinYinHelper
    {
        /// <summary>
        /// Gets the initials.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string GetInitials(this string str)
        {
            str = str.Trim();
            var pingyins = new StringBuilder();
            for (var i = 0; i < str.Length; ++i)
            {
                var pinying = str[i].GetPinYin();
                if (pinying != "")
                {
                    pingyins.Append(pinying[0]);
                }
            }

            return pingyins.ToString();
        }

        /// <summary>
        /// Gets the pin yin.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string GetPinYin(this string str)
        {
            var pingyins = new StringBuilder();
            for (var i = 0; i < str.Length; ++i)
            {
                var pinying = str[i].GetPinYin();
                if (pinying != "")
                {
                    pingyins.Append(pinying);
                }
                pingyins.Append(' ');
            }

            return pingyins.ToString().Trim();
        }

        /// <summary>
        /// Gets the chinese text.
        /// </summary>
        /// <param name="pinyin">The pinyin.</param>
        /// <returns>System.String.</returns>
        public static string GetChineseText(this string pinyin)
        {
            var key = pinyin.Trim().ToLower();

            foreach (var str in PinYinCode.Codes)
            {
                if (str.StartsWith(key + " ") || str.StartsWith(key + ":"))
                {
                    return str[7..];
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the pin yin.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns>System.String.</returns>
        public static string GetPinYin(this char ch)
        {
            var hash = GetHashIndex(ch);
            for (var i = 0; i < PinYinHash.Hashes[hash].Length; ++i)
            {
                var index = PinYinHash.Hashes[hash][i];
                var pos = PinYinCode.Codes[index].IndexOf(ch);
                if (pos != -1)
                {
                    return PinYinCode.Codes[index].Split(":")[0];
                }
            }
            return ch.ToString();
        }

        /// <summary>
        /// Gets the index of the hash.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns>System.Int16.</returns>
        private static short GetHashIndex(char ch) => (short)((uint)ch % PinYinCode.Codes.Length);
    }
}