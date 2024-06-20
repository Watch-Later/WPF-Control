﻿

using H.Extensions.Encryption;
using H.Providers.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class Extention
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="service"></param>
        public static void AddDESCryptService(this IServiceCollection service)
        {
            service.AddSingleton<ICryptService, DESCryptService>();
        }
    }
}
