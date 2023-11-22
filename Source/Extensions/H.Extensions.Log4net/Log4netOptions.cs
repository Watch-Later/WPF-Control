﻿using H.Extensions.Setting;
using H.Providers.Ioc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace H.Extensions.Revertible
{
    [Display(Name = "日志配置", GroupName = SystemSetting.GroupSystem, Description = "登录页面设置的信息")]
    public class Log4netOptions : IocOptionInstance<Log4netOptions>
    {
        public override void LoadDefault()
        {
            base.LoadDefault();
            this.LogPath = SystemPathSetting.Instance.Log;
            this.tempPath = SystemPathSetting.Instance.Cache;
        }

        private string _logPath;
        [Display(Name = "日志路径")]
        public string LogPath
        {
            get { return _logPath; }
            set
            {
                _logPath = value;
                RaisePropertyChanged();
            }
        }

        private string _tempPath;
        [Display(Name = "缓存路径")]
        public string tempPath
        {
            get { return _tempPath; }
            set
            {
                _tempPath = value;
                RaisePropertyChanged();
            }
        }
    }
}
