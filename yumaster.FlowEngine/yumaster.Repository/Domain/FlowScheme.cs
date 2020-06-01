﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using yumaster.Repository.Core;

namespace yumaster.Repository.Domain
{
    /// <summary>
    /// 工作流模板信息表
    /// </summary>
    [Table("FlowScheme")]
    public partial class FlowScheme : Entity
    {
        public FlowScheme()
        {
            this.SchemeCode = string.Empty;
            this.SchemeName = string.Empty;
            this.SchemeType = string.Empty;
            this.SchemeVersion = string.Empty;
            this.SchemeCanUser = string.Empty;
            this.SchemeContent = string.Empty;
            this.FrmId = string.Empty;
            this.FrmType = 0;
            this.AuthorizeType = 0;
            this.SortCode = 0;
            this.DeleteMark = 0;
            this.Disabled = 0;
            this.Description = string.Empty;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = string.Empty;
            this.CreateUserName = string.Empty;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = string.Empty;
            this.ModifyUserName = string.Empty;
        }

        /// <summary>
        /// 流程编号
        /// </summary>
        [Description("流程编号")]
        public string SchemeCode { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        [Description("流程名称")]
        public string SchemeName { get; set; }
        /// <summary>
        /// 流程分类
        /// </summary>
        [Description("流程分类")]
        public string SchemeType { get; set; }
        /// <summary>
        /// 流程内容版本
        /// </summary>
        [Description("流程内容版本")]
        public string SchemeVersion { get; set; }
        /// <summary>
        /// 流程模板使用者
        /// </summary>
        [Description("流程模板使用者")]
        public string SchemeCanUser { get; set; }
        /// <summary>
        /// 流程内容
        /// </summary>
        [Description("流程内容")]
        public string SchemeContent { get; set; }
        /// <summary>
        /// 表单ID
        /// </summary>
        [Description("表单ID")]
        public string FrmId { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        [Description("表单类型")]
        public int FrmType { get; set; }
        /// <summary>
        /// 模板权限类型：0完全公开,1指定部门/人员
        /// </summary>
        [Description("模板权限类型：0完全公开,1指定部门/人员")]
        public int AuthorizeType { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Description("排序码")]
        public int SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        [Description("删除标记")]
        public int DeleteMark { get; set; }
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        public int Disabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        [Description("创建用户主键")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        [Description("创建用户")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        public System.DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        [Description("修改用户主键")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        [Description("修改用户")]
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [Description("所属部门")]
        public string OrgId { get; set; }

    }
}
