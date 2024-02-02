﻿using H.Controls.FavoriteBox;
using H.Controls.TagBox;
using H.Extensions.ApplicationBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace H.Test.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override Window CreateMainWindow(StartupEventArgs e)
        {
            return new MainWindow();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddAdornerDialogMessage();
            services.AddFormMessageService();
            services.AddLog4net();
            services.AddSetting();
            services.AddXmlMetaSettingService();
            services.AddTag(x =>
            {
                x.Tags.Add(new Tag() { Name = "严重", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.Tags.Add(new Tag() { Name = "错误", Description = "这是一个严重标签", Background = Brushes.Red });
                x.Tags.Add(new Tag() { Name = "警告", Description = "这是一个严重标签", Background = Brushes.Orange });
                x.Tags.Add(new Tag() { Name = "运行", Description = "这是一个严重标签", Background = Brushes.Blue });
                x.Tags.Add(new Tag() { Name = "成功", Description = "这是一个严重标签", Background = Brushes.Green });

                x.Tags.Add(new Tag() { Name = "测试1", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.Tags.Add(new Tag() { Name = "测试2", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Red });
                x.Tags.Add(new Tag() { Name = "测试3", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Orange });
                x.Tags.Add(new Tag() { Name = "测试4", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Blue });
                x.Tags.Add(new Tag() { Name = "测试5", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Green });
            });

            services.AddFavorite(x =>
            {
                x.FavoriteItems.Add(new FavoriteItem() { Path = "1", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.FavoriteItems.Add(new FavoriteItem() { Path = "1\\1", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.FavoriteItems.Add(new FavoriteItem() { Path = "1\\1\\1", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.FavoriteItems.Add(new FavoriteItem() { Path = "2", Description = "这是一个严重标签", Background = Brushes.Purple });
                x.FavoriteItems.Add(new FavoriteItem() { Path = "2\\1", Description = "这是一个严重标签", Background = Brushes.Purple });

                //var r= "1".Contains(System.IO.Path.DirectorySeparatorChar);

                //var ss=  System.IO.Path.GetDirectoryName("2\\1");
                //x.Tags.Add(new Tag() { Name = "测试1", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Purple });
                //x.Tags.Add(new Tag() { Name = "测试2", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Red });
                //x.Tags.Add(new Tag() { Name = "测试3", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Orange });
                //x.Tags.Add(new Tag() { Name = "测试4", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Blue });
                //x.Tags.Add(new Tag() { Name = "测试5", GroupName = "Test", Description = "这是一个严重标签", Background = Brushes.Green });
            });

            services.AddSchedule();
            services.AddMail();
            services.AddFeedBack();
        }

        protected override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);
            app.UseAddLog4netSetting();
            app.UseVlc(x =>
            {
                x.LibvlcPath = "G:\\BaiduNetdiskDownload\\libvlc\\win-x64";
            });

            app.UseMail();
        }
    }
}
