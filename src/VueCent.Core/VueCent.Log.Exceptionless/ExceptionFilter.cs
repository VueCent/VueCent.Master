// ***********************************************************************
// Assembly         : VueCent.Log.Exceptionless
// Author           : Administrator
// Created          : 04-12-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ExceptionFilter.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace VueCent.Log.Exceptionless
{
    /// <summary>
    /// Class ExceptionFilter.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter" />
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// Called when [exception asynchronous].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            return Task.Run(() =>
            {
                new ExceptionlessHelper().Error(context.Exception.Message);
            });
        }
    }
}