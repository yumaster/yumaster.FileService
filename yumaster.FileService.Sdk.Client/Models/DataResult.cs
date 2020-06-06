﻿namespace yumaster.FileService.Sdk.Client.Models
{
    public class DataResult<TData> : Result, IDataResult<TData> where TData : class
    {
        public DataResult()
        {
        }

        public DataResult(int errorCode = ResultErrorCodes.Unknown, string errorMsg = null, TData data = default(TData))
            : base(errorCode, errorMsg)
        {
            Data = data;
        }

        /// <summary>
        /// API结果的数据内容
        /// </summary>
        public TData Data { get; set; }
    }
}
