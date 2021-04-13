// ***********************************************************************
// Assembly         : VueCent.Grpc
// Author           : Administrator
// Created          : 04-13-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="IConfig.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace VueCent.Grpc
{
    /// <summary>
    /// Interface IConfig
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        string Host { get; set; }
    }
}