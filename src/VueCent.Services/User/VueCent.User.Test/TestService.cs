// ***********************************************************************
// Assembly         : VueCent.User.Test
// Author           : Administrator
// Created          : 03-23-2021
//
// Last Modified By : Administrator
// Last Modified On : 03-25-2021
// ***********************************************************************
// <copyright file="TestService.cs" company="VueCent.User.Test">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VueCent.User.DTO;

namespace VueCent.User.Test
{
    /// <summary>
    /// Defines test class TestService.
    /// </summary>
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void TestUserService()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:7200");
            var client = new Users.UsersClient(channel);
            var reply = client.GetUser(new UserRequest { UserName = "Grpc", Password = "123456" });
            Console.WriteLine("Users: " + reply.Id);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}