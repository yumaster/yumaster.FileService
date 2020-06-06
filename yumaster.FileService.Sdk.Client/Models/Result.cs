﻿using Newtonsoft.Json;

namespace yumaster.FileService.Sdk.Client.Models
{
    /// <summary>
    /// API结果通用类
    /// </summary>
    public class Result : IResult
    {
        static Result()
        {
            Success = new Result(ResultErrorCodes.Success);
        }

        public Result() : this(ResultErrorCodes.Unknown, null)
        {
        }

        public Result(int errorCode = ResultErrorCodes.Unknown, string errorMsg = null)
        {
            this.ErrorCode = errorCode;
            this.ErrorMsg = errorMsg;
        }

        /// <summary>
        /// 错误代码。
        /// 100以下参见<see cref="ResultErrorCodes"/>的定义 | 100及以上参见具体接口的定义
        /// </summary>
        [JsonProperty("errCode")]
        public int ErrorCode { get; set; }
        /// <summary>
        /// 如果接口失败，此字段为失败原因
        /// </summary>
        [JsonProperty("errMsg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 表示成功的IResult
        /// </summary>
        public static IResult Success { get; }
    }
}
