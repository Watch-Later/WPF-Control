﻿using H.Extensions.Setting;
using H.Providers.Ioc;
using H.Providers.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace H.Styles.Default
{
    public class WindowKeys
    {
        public static ComponentResourceKey Button => new ComponentResourceKey(typeof(WindowKeys), "S.Window.Button");
        public static ComponentResourceKey WindowChrome => new ComponentResourceKey(typeof(WindowKeys), "S.Window.WindowChrome");
    }

    [Display(Name = "窗口设置", GroupName = SystemSetting.GroupSystem, Description = "设置窗口参数")]
    public class WindowSetting : Setting<WindowSetting>
    {
        private string _backImagePath;
        [Displayer(Name = "窗口背景图片")]
        public string BackImagePath
        {
            get { return _backImagePath; }
            set
            {
                _backImagePath = value;
                RaisePropertyChanged();
            }
        }

        private double _opacity;
        [DefaultValue(0.3)]
        [Displayer(Name = "图片透明度")]
        public double Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                RaisePropertyChanged();
            }
        }


        private Stretch _stretch;
        [DefaultValue(Stretch.UniformToFill)]
        [Displayer(Name = "图片拉伸")]
        public Stretch Stretch
        {
            get { return _stretch; }
            set
            {
                _stretch = value;
                RaisePropertyChanged();
            }
        }
    }

    public static partial class Extension
    {
        public static IApplicationBuilder UseWindowSetting(this IApplicationBuilder builder, Action<WindowSetting> option = null)
        {
            SettingDataManager.Instance.Add(WindowSetting.Instance);
            option?.Invoke(WindowSetting.Instance);
            return builder;
        }
    }

}
