﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using yumaster.FileService.Authorization;
using yumaster.FileService.Authorization.Options;

namespace yumaster.FileService.Sdk.Server
{
    /// <summary>
    /// FileService的IServiceCollection扩展
    /// </summary>
    public static class ServiceServiceCollectionSdkExtensions
    {
        /// <summary>
        /// 添加FileService.Sdk.Server的相关服务
        /// </summary>
        public static void AddFileService(this IServiceCollection services)
        {
            ServiceConfigure.AddAuthorization(services);
            services.AddSingleton<IFileServiceManager, FileServiceManager>();
            services.AddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();

            services.Configure<HttpClientFactoryOptions>(opt => { });
        }

        public static void AddFileService(this IServiceCollection services, Action<FileServiceOption> configure)
        {
            AddFileService(services);

            services.Configure(configure);

            var opt = new FileServiceOption();
            configure(opt);
            services.Configure<AuthOption>(x =>
            {
                x.AppSecret = opt.AppSecret;
            });
        }
    }
}
