﻿namespace yumaster.FileService.Sdk.Server.Models.Output
{
    /// <summary>
    /// 操作结果接口定义
    /// </summary>
    public interface IResult
    {
        int ErrorCode { get; set; }
        string ErrorMsg { get; set; }
    }
}
