// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ModelMessage.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Data
{
    /// <summary>
    /// Class ModelMessage. This class cannot be inherited.
    /// Implements the <see cref="VueCent.Data.BaseMessage" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="VueCent.Data.BaseMessage" />
    public sealed class ModelMessage<T> : BaseMessage
        where T : class
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; set; }

        /// <summary>
        /// Errors the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>ModelMessage&lt;T&gt;.</returns>
        public override ModelMessage<T> Error(int code, string message)
        {
            base.Error(code, message);
            Data = null;
            return this;
        }

        /// <summary>
        /// Succees the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ModelMessage&lt;T&gt;.</returns>
        public override ModelMessage<T> Succee(string message = "")
        {
            base.Succee(message);
            return this;
        }
    }
}