﻿using System;
using System.Collections.Generic;
using System.Text;

namespace yumaster.FlowEngine.Response
{
    /// <summary>
	/// 表单模板表
	/// </summary>
    public class FormResp
    {
        /// <summary>
	    /// 表单名称
	    /// </summary>
        public string Id { get; set; }

        /// <summary>
	    /// 表单名称
	    /// </summary>
        public string Name { get; set; }
        /// <summary>
	    /// 字段个数
	    /// </summary>
        public int Fields { get; set; }
        /// <summary>
        /// 表单类型，0：默认动态表单；1：Web自定义表单
        /// </summary>
        public int FrmType { get; set; }
        /// <summary>
        /// 系统页面标识，当表单类型为用Web自定义的表单时，需要标识加载哪个页面
        /// </summary>
        public string WebId { get; set; }
        /// <summary>
	    /// 表单中的字段数据
	    /// </summary>
        public string ContentData { get; set; }
        /// <summary>
	    /// 表单替换的模板 经过处理
	    /// </summary>
        public string ContentParse { get; set; }
        /// <summary>
	    /// 表单原html模板未经处理的
	    /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }

        public string Description { get; set; }


        /// <summary>
	    /// 数据库名称
	    /// </summary>
        public string DbName { get; set; }
        /// <summary>
        /// 用户显示
        /// </summary>
        public string Html
        {
            get { return FormUtil.GetHtml(this); }
        }

    }
}
