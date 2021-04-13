// ***********************************************************************
// Assembly         : VueCent.Register.Consul
// Author           : Administrator
// Created          : 03-22-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="ConsulHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using Consul;
using System;
using System.Linq;

namespace VueCent.Register.Consul
{
    /// <summary>
    /// Class ConsulHelper.
    /// Implements the <see cref="VueCent.Register.IRegister" />
    /// </summary>
    /// <seealso cref="VueCent.Register.IRegister" />
    public class ConsulHelper : IRegister
    {
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public static string BaseUrl { get; set; }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>The client.</value>
        public ConsulClient Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsulHelper" /> class.
        /// </summary>
        public ConsulHelper()
        {
            Client = new ConsulClient(config =>
            {
                config.Address = new Uri(BaseUrl);
                config.Datacenter = "dcl";
            });
        }

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IConfig.</returns>
        public IConfig Get(string name)
        {
            var services = Client.Agent.Services().Result.Response.Values.Where(x => x.Service == name).ToList();
            if (services.Any())
            {
                var rand = new Random();
                var index = rand.Next(services.Count);
                var service = services.ElementAt(index);
                return new Config()
                {
                    IP = service.Address,
                    Port = service.Port,
                    Host = service.Tags.FirstOrDefault()
                };
            }
            return null;
        }

        /// <summary>
        /// Sets the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void Set(IConfig config)
        {
            var register = config as Config;

            var healthCheck = new AgentServiceCheck()
            {
                HTTP = $"http://{register.IP}:{register.Port}/Health/Check",
                Interval = TimeSpan.FromSeconds(register.Interval),
                Timeout = TimeSpan.FromSeconds(register.Timeout),
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(register.DeregisterCriticalServiceAfter),
            };

            var registration = new AgentServiceRegistration()
            {
                ID = $"{register.Name}:{register.Port}",
                Name = register.Name,
                Address = register.IP,
                Port = register.Port,
                Tags = new string[] { register.Host },
                Checks = new[] { healthCheck }
            };

            Client.Agent.ServiceRegister(registration).Wait();
        }
    }
}