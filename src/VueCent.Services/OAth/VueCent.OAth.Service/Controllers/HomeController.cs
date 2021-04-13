// ***********************************************************************
// Assembly         : VueCent.OAth.Service
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 03-11-2021
// ***********************************************************************
// <copyright file="HomeController.cs" company="VueCent.OAth.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VueCent.OAth.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index() => await Task.Run(() => Content("OAth Is Running ."));

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Error() => await Task.Run(() => Content("Error"));
    }
}