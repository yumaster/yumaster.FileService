﻿using System.Collections.Generic;

namespace yumaster.FileService.Sdk.Client.Models
{
    /// <summary>
    /// 列表或数组数据
    /// </summary>
    public class ItemsData<T>
    {
        public ItemsData()
        {
        }

        public ItemsData(IList<T> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// 数据项列表
        /// </summary>
        public IList<T> Items { get; set; }
    }
}
