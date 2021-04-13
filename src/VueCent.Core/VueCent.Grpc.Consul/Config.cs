// ***********************************************************************
// Assembly         : VueCent.Grpc.Consul
// Author           : Administrator
// Created          : 04-13-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="Config.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace VueCent.Grpc.Consul
{
    /// <summary>
    /// Class Config.
    /// Implements the <see cref="VueCent.Grpc.IConfig" />
    /// </summary>
    /// <seealso cref="VueCent.Grpc.IConfig" />
    public class Config : IConfig
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string Host { get; set; }
    }
}