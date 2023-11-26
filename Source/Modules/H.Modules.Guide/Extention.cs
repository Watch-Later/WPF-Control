﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using H.Modules.Guide;
using H.Providers.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Media;

namespace System
{
    public static class Extention
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="service"></param>
        public static IServiceCollection AddGuideService(this IServiceCollection services, Action<GuideOptions> setupAction = null)
        {
            services.AddOptions();
            services.TryAdd(ServiceDescriptor.Singleton<IGuideService, GuideService>());
            if (setupAction != null)
                services.Configure(setupAction);
            return services;
        }

        ///// <summary>
        ///// 设置显示新手向导
        ///// </summary>  
        //public static IServiceCollection AddGuideViewPresenter(this IServiceCollection services, Action<IGuideViewPresenterOption> option = null)
        //{
        //    //services.AddWindowCaptionViewPresenter();
        //    services.AddSingleton<IGuideViewPresenter, GuideViewPresenter>();
        //    option?.Invoke(GuideViewPresenter.Instance);
        //    SettingDataManager.Instance.Add(GuideViewPresenter.Instance);
        //    //WindowCaptionViewPresenter.Instance.AddPersenter(GuideViewPresenter.Instance);
        //    return services;
        //}
    }
}
