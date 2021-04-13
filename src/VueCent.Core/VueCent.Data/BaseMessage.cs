// ***********************************************************************
// Assembly         : VueCent.Data
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="BaseMessage.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Data
{
    /// <summary>
    /// Class BaseMessage.
    /// </summary>
    public class BaseMessage
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseMessage" /> is succeed.
        /// </summary>
        /// <value><c>true</c> if succeed; otherwise, <c>false</c>.</value>
        private bool S { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether this <see cref="BaseMessage" /> is succeed.
        /// </summary>
        /// <value><c>true</c> if succeed; otherwise, <c>false</c>.</value>
        public bool Succeed => S;

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        private int C { get; set; } = 200;

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public int Code => C;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        private string M { get; set; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message => M;

        /// <summary>
        /// Errors the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>BaseMessage.</returns>
        public virtual BaseMessage Error(int code, string message)
        {
            S = false;
            this.C = code;
            this.M = message;
            return this;
        }

        /// <summary>
        /// Succees the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>BaseMessage.</returns>
        public virtual BaseMessage Succee(string message = "")
        {
            S = true;
            C = 200;
            this.M = message;
            return this;
        }
    }
}