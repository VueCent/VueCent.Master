// ***********************************************************************
// Assembly         : VueCent.Web
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="CookieHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace VueCent.Web
{
    /// <summary>
    /// Class CookieHelper. This class cannot be inherited.
    /// </summary>
    public sealed class CookieHelper
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly HttpContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CookieHelper" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CookieHelper(HttpContext context) => _context = context;

        /// <summary>
        /// Sets the cookie.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetCookie(string key, string value) => SetCookie(key, value, 0);

        /// <summary>
        /// Sets the cookie.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="day">The day.</param>
        public void SetCookie(string key, string value, double day)
            => _context.Response.Cookies.Append(key, value, new CookieOptions { Expires = DateTime.Now.AddDays(day) });

        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string GetCookie(string key)
        {
            _context.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }

        /// <summary>
        /// Clears the cookie.
        /// </summary>
        public void ClearCookie() => _context.Request.Cookies.Keys.ToList().ForEach(x => ClearCookie(x));

        /// <summary>
        /// Clears the cookie.
        /// </summary>
        /// <param name="key">The key.</param>
        public void ClearCookie(string key) => _context.Response.Cookies.Delete(key);
    }
}