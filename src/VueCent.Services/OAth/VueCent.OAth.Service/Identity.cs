// ***********************************************************************
// Assembly         : VueCent.OAth.Service
// Author           : Administrator
// Created          : 03-24-2021
//
// Last Modified By : Administrator
// Last Modified On : 03-11-2021
// ***********************************************************************
// <copyright file="Identity.cs" company="VueCent.OAth.Service">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using IdentityServer4.Models;
using System.Collections.Generic;

namespace VueCent.OAth.Service
{
    /// <summary>
    /// Class Identity.
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// Gets the API scopes.
        /// </summary>
        /// <value>The API scopes.</value>
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api", "api")
            };

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api" }
                }
            };
    }
}