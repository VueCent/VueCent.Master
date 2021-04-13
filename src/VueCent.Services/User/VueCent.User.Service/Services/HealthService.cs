// ***********************************************************************
// Assembly         : VueCent.User.Service
// Author           : Administrator
// Created          : 03-25-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-07-2021
// ***********************************************************************
// <copyright file="HealthService.cs" company="VueCent.User.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Grpc.Core;
using System.Threading.Tasks;
using VueCent.User.DTO;

namespace VueCent.User.Service.Services
{
    /// <summary>
    /// Class HealthService.
    /// Implements the <see cref="VueCent.User.DTO.Health.HealthBase" />
    /// </summary>
    /// <seealso cref="VueCent.User.DTO.Health.HealthBase" />
    public class HealthService : Health.HealthBase
    {
        /// <summary>
        /// Checks the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;HealthCheckReply&gt;.</returns>
        public override async Task<HealthCheckReply> Check(HealthCheckRequest request, ServerCallContext context) => await Task.Run(() => new HealthCheckReply());
    }
}