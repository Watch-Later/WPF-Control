﻿

using H.Extensions.Excel;
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
        public static void AddNPOI(this IServiceCollection service)
        {
            service.AddSingleton<IExcelService, NpoiService>();
        }
    }
}
