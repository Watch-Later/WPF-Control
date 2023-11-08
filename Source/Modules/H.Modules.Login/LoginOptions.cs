﻿using H.Extensions.Common;
using H.Extensions.Setting;
using H.Providers.Ioc;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace H.Modules.Login
{
    [Display(Name = "登录页面", GroupName = SystemSetting.GroupSystem, Description = "登录页面设置的信息")]
    public class LoginOptions : IocOptionInstance<LoginOptions>
    {
        public LoginOptions()
        {
            this.Product = ApplicationProvider.Product;
        }

        [Display(Name = "登录标题")]
        public string Product { get; set; } = "我是名称";

        [Display(Name = "字体大小")]
        public double ProductFontSize { get; set; } = 50;

        private string _userName;
        [DefaultValue("admin")]
        [Required]
        [Display(Name = "管理员账号")]
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        private string _password;
        [XmlIgnore]
        [JsonIgnore]
        [DefaultValue("123456")]
        [Required]
        [Display(Name = "管理员密码")]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        private string _lastUserName;
        [DefaultValue("admin")]
        [Display(Name = "上次登录用户")]
        public string LastUserName
        {
            get { return _lastUserName; }
            set
            {
                _lastUserName = value;
                RaisePropertyChanged();
            }
        }

        private string _lastPassword;
        [DefaultValue("123456")]
        [Display(Name = "上次登录密码")]
        public string LastPassword
        {
            get { return _lastPassword; }
            set
            {
                _lastPassword = value;
                RaisePropertyChanged();
            }
        }

        private bool _remember = true;
        [Display(Name = "记住密码")]
        public bool Remember
        {
            get { return _remember; }
            set
            {
                _remember = value;
                RaisePropertyChanged();
            }
        }

        private bool _useVisitor = false;
        [DefaultValue(false)]
        [Display(Name = "启用访客", Description = "启用访客模式后登录不成功也可以进入主窗口")]
        public bool UseVisitor
        {
            get { return _useVisitor; }
            set
            {
                _useVisitor = value;
                RaisePropertyChanged();
            }
        }

    }
}
