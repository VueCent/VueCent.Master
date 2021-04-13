// ***********************************************************************
// Assembly         : VueCent.Grpc
// Author           : Administrator
// Created          : 04-13-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IGrpc.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Grpc
{
    /// <summary>
    /// Interface IGrpc
    /// </summary>
    public interface IGrpc
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

        /// <summary>
        /// Invokes the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="action">The action.</param>
        /// <param name="t">The t.</param>
        /// <returns>V.</returns>
        V Invoke<T, V>(string name, string action, T t) where V : class where T : class;
    }
}