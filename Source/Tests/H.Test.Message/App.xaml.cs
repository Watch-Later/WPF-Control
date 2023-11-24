﻿using H.Extensions.ApplicationBase;
using H.Modules.Message;
using H.Providers.Ioc;
using H.Styles.Default;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace H.Test.Message
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IDialogMessage, WindowDialogMessage>();
            services.AddSingleton<IDialogMessage, AdornerDialogMessage>();
            services.AddSingleton<IFormMessage, FormMessage>();
            services.AddNoticeMessage();
            services.AddAbout();


            //var sss= SystemColors.ControlDarkColor.ToString();
            // System.Diagnostics.Debug.WriteLine(sss);
         var ss=   SystemParameters.WindowCaptionButtonHeight;

        }

        protected override Window CreateMainWindow(StartupEventArgs e)
        {
            return new MainWindow();
        }
    }
}
