﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using yumaster.Repository.Core;

namespace yumaster.Repository.Domain
{
    /// <summary>
    /// 系统授权规制表
    /// </summary>
    [Table("DataPrivilegeRule")]
    public partial class DataPrivilegeRule : Entity
    {
        public DataPrivilegeRule()
        {
            this.SourceCode = string.Empty;
            this.SubSourceCode = string.Empty;
            this.Description = string.Empty;
            this.SortNo = 0;
            this.PrivilegeRules = string.Empty;
            this.CreateTime = DateTime.Now;
            this.CreateUserId = string.Empty;
            this.CreateUserName = string.Empty;
            this.UpdateTime = DateTime.Now;
            this.UpdateUserId = string.Empty;
            this.UpdateUserName = string.Empty;
        }

        /// <summary>
        /// 资源标识（模块编号）
        /// </summary>
        [Description("模块编号")]
        public string SourceCode { get; set; }
        /// <summary>
        /// 二级资源标识
        /// </summary>
        [Description("二级资源标识")]
        [Browsable(false)]
        public string SubSourceCode { get; set; }
        /// <summary>
        /// 权限描述
        /// </summary>
        [Description("权限描述")]
        public string Description { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Description("排序号")]
        public int SortNo { get; set; }
        /// <summary>
        /// 权限规则
        /// </summary>
        [Description("权限规则")]
        public string PrivilegeRules { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        [Description("是否可用")]
        public bool Enable { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Description("创建人ID")]
        [Browsable(false)]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        public System.DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 最后更新人ID
        /// </summary>
        [Description("最后更新人ID")]
        [Browsable(false)]
        public string UpdateUserId { get; set; }
        /// <summary>
        /// 最后更新人
        /// </summary>
        [Description("最后更新人")]
        public string UpdateUserName { get; set; }
    }
}
