// ***********************************************************************
// Assembly         : VueCent.User.Service
// Author           : Administrator
// Created          : 03-24-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-01-2021
// ***********************************************************************
// <copyright file="UserService.cs" company="VueCent.User.Service">
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
    /// Class UserService.
    /// Implements the <see cref="VueCent.User.DTO.Users.UsersBase" />
    /// </summary>
    /// <seealso cref="VueCent.User.DTO.Users.UsersBase" />
    public class UserService : Users.UsersBase
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;UserReply&gt;.</returns>
        public override async Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                return new UserReply()
                {
                    Id = 99,
                    UserName = request.UserName
                };
            });
        }

        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;UserReply&gt;.</returns>
        public override async Task<UserReply> PostUser(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                return new UserReply()
                {
                    Id = 99,
                    UserName = request.UserName
                };
            });
        }

        /// <summary>
        /// Gets the base message.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;BaseMessage&gt;.</returns>
        public override async Task<BaseMessage> GetBaseMessage(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                return new BaseMessage()
                {
                    Succeed = true,
                    Code = "",
                    Message = request.UserName
                };
            });
        }

        /// <summary>
        /// Gets the mode message.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;ModeMessage&gt;.</returns>
        public override async Task<ModeMessage> GetModeMessage(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                return new ModeMessage()
                {
                    Succeed = true,
                    Code = "",
                    Message = request.UserName,
                    Data = new UserReply()
                    {
                        Id = 99,
                        UserName = request.UserName
                    }
                };
            });
        }

        /// <summary>
        /// Gets the page message.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;PageMessage&gt;.</returns>
        public override async Task<PageMessage> GetPageMessage(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var page = new PageMessage()
                {
                    Succeed = true,
                    Code = "",
                    Message = request.UserName,
                    Offset = 1,
                    Limit = 10,
                    Total = 23
                };
                page.Rows.Add(new UserReply()
                {
                    Id = 99,
                    UserName = request.UserName
                });
                return page;
            });
        }

        /// <summary>
        /// Gets the key value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;KeyValue&gt;.</returns>
        public override async Task<KeyValue> GetKeyValue(UserRequest request, ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var kv = new KeyValue()
                {
                    Key = request.UserName
                };
                kv.Value.Add(new UserReply()
                {
                    Id = 99,
                    UserName = request.UserName
                });
                return kv;
            });
        }
    }
}