// ***********************************************************************
// Assembly         : VueCent.Web
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="SessionHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace VueCent.Web
{
    /// <summary>
    /// Class SessionHelper. This class cannot be inherited.
    /// </summary>
    public sealed class SessionHelper
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly HttpContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionHelper" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SessionHelper(HttpContext context) => _context = context;

        /// <summary>
        /// Clears the session.
        /// </summary>
        public void ClearSession() => _context.Session.Keys.ToList().ForEach(x => ClearSession(x));

        /// <summary>
        /// Clears the session.
        /// </summary>
        /// <param name="key">The key.</param>
        public void ClearSession(string key) => _context.Session.Remove(key);

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string GetSession(string key) => _context.Session.GetString(key) ?? string.Empty;

        /// <summary>
        /// Sets the session.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetSession(string key, string value) => _context.Session.SetString(key, value);
    }
}