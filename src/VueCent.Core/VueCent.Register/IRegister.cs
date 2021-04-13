// ***********************************************************************
// Assembly         : VueCent.Register
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IRegister.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Register
{
    /// <summary>
    /// Interface IRegister
    /// </summary>
    public interface IRegister
    {
        /// <summary>
        /// Sets the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        void Set(IConfig config);

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IConfig.</returns>
        IConfig Get(string name);
    }
}