﻿
using H.Modules.About;
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
        public static void AddAbout(this IServiceCollection service, Action<IAboutViewPresenterOption> action = null)
        {
            service.AddSingleton<IAboutViewPresenter, AboutViewPresenter>();
            service.AddSingleton<IAboutButtonPresenter, AboutButtonPresenter>();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="service"></param>
        public static void UseAbout(this IApplicationBuilder service, Action<IAboutViewPresenterOption> action = null)
        {
            action?.Invoke(AboutViewPresenter.Instance);
        }
    }
}
