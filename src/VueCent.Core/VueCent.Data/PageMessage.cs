// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="PageMessage.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace VueCent.Data
{
    /// <summary>
    /// Class PageMessage. This class cannot be inherited.
    /// Implements the <see cref="VueCent.Data.BaseMessage" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Data.BaseMessage" />
    public sealed class PageMessage<T> : BaseMessage
        where T : class
    {
        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public IEnumerable<T> Rows { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int Total { get; set; }

        /// <summary>
        /// Errors the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>PageMessage&lt;T&gt;.</returns>
        public override PageMessage<T> Error(int code, string message)
        {
            base.Error(code, message);
            Total = 0;
            Rows = null;
            Limit = 0;
            Offset = 0;
            return this;
        }

        /// <summary>
        /// Succees the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>PageMessage&lt;T&gt;.</returns>
        public override PageMessage<T> Succee(string message = "")
        {
            base.Succee(message);
            return this;
        }
    }
}