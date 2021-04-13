// ***********************************************************************
// Assembly         : VueCent.Database.BLL
// Author           : Administrator
// Created          : 04-08-2021
//
// Last Modified By : Administrator
// Last Modified On : 04-12-2021
// ***********************************************************************
// <copyright file="SysUserBLL.cs" company="VueCent.Database.BLL">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using VueCent.Database.DAL;
using VueCent.Database.Model;
using VueCent.Factory;
using VueCent.Factory.SqlSuagr;

namespace VueCent.Database.BLL
{
    /// <summary>
    /// Class SysUserBLL.
    /// Implements the <see cref="VueCent.Factory.SqlSuagr.BaseTableBLL{VueCent.Database.Model.SysUserModel}" />
    /// </summary>
    /// <seealso cref="VueCent.Factory.SqlSuagr.BaseTableBLL{VueCent.Database.Model.SysUserModel}" />
    public class SysUserBLL : BaseTableBLL<SysUserModel>
    {
        /// <summary>
        /// Gets the dal.
        /// </summary>
        /// <value>The dal.</value>
        public override IBaseTableDAL<SysUserModel> DAL => new SysUserDAL();
    }
}