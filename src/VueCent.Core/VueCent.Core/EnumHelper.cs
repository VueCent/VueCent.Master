// ***********************************************************************
// Assembly         : VueCent.Core
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="EnumHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Linq;

namespace VueCent.Core
{
    /// <summary>
    /// Class EnumHelper.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Converts to description.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>System.String.</returns>
        public static string ToDescription(this Enum enums)
        {
            var fieldInfo = enums.GetType().GetField(enums.ToString());
            if (fieldInfo != null)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Any())
                {
                    return attributes.FirstOrDefault().Description;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this Enum enums)
        {
            var strValue = enums.ToString();
            var fieldinfo = enums.GetType().GetField(strValue);
            if (fieldinfo == null)
            {
                return strValue;
            }
            var objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0)
            {
                return strValue;
            }
            else
            {
                var da = (DescriptionAttribute)objs[0];
                return da.Description;
            }
        }

        /// <summary>
        /// Gets the description by value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDescriptionByValue<T>(int value)
        {
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var outObj = Enum.Parse(typeof(T), item.ToString()) as Enum;
                if (value == Convert.ToInt32(outObj))
                {
                    return outObj.GetDescription();
                }
            }
            return string.Empty;
        }
    }
}