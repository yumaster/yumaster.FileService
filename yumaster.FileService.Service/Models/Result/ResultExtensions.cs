﻿using System;
using System.Collections.Generic;
using System.Text;

namespace yumaster.FileService.Service.Models.Result
{
    /// <summary>
    /// IResult的扩展方法
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// 当前结果是否成功？
        /// </summary>
        public static bool IsSuccess(this IResult result) => result.ErrorCode == ResultErrorCodes.Success;
    }
}
