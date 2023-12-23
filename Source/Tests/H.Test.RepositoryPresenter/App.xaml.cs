﻿using H.DataBases.Share;
using H.DataBases.Sqlite;
using H.Extensions.ApplicationBase;
using H.Extensions.ViewModel;
using H.Providers.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace H.Test.RepositoryPresenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSetting();
            services.AddAdornerDialogMessage();
            services.AddWindowMessage();
            services.AddDbContextBySetting<MyDataContext>();
            services.AddSingleton<IStringRepository<mbc_dv_image>, DbContextRepository<MyDataContext, mbc_dv_image>>();
            services.AddSingleton<IRepositoryViewModel<mbc_dv_image>, RepositoryViewModel<mbc_dv_image>>();
        }

        protected override Window CreateMainWindow(StartupEventArgs e)
        {
            return new MainWindow();
        }

        protected override void OnSplashScreen(StartupEventArgs e)
        {
            base.OnSplashScreen(e);

            var loads = Ioc.Services.GetServices<IDbConnectService>();
            foreach (var load in loads)
            {
                load.Load(out string error);
            }
        }
    }
}
