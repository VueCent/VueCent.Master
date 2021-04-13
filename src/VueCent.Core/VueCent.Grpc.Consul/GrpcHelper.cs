// ***********************************************************************
// Assembly         : VueCent.Grpc.Consul
// Author           : Administrator
// Created          : 04-13-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-13-2021
// ***********************************************************************
// <copyright file="GrpcHelper.cs" company="VueCent">
//     VueCent © All Right
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using VueCent.Core;
using VueCent.Register.Consul;

namespace VueCent.Grpc.Consul
{
    /// <summary>
    /// Class GrpcHelper.
    /// Implements the <see cref="VueCent.Grpc.IGrpc" />
    /// </summary>
    /// <seealso cref="VueCent.Grpc.IGrpc" />
    public class GrpcHelper : IGrpc
    {
        /// <summary>
        /// The list
        /// </summary>
        private static readonly List<IConfig> List = new();

        public IConfig Get(string name) => List.FirstOrDefault(x => x.Name == name);

        public V Invoke<T, V>(string name, string action, T t)
            where T : class
            where V : class
        {
            var service = new ConsulHelper().Get(name);

            if (service != null)
            {
                var url = $"http://{service.IP}:{service.Port}/api/{service.Host}/{action}";
                using var content = new StringContent(t.ToJson(), Encoding.UTF8, "application/json");
                using var http = new HttpClient();
                var result = http.PostAsync(url, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string json = result.Content.ReadAsStringAsync().Result;
                    return JsonHelper.DeJson<V>(json);
                }
            }

            return default;
        }

        public void Set(IConfig config)
        {
            var model = List.FirstOrDefault(x => x.Name == config.Name);
            if (model == null)
            {
                List.Add(config);
            }
            else
            {
                model.Host = config.Host;
            }
        }
    }
}