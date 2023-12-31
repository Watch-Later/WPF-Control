﻿using H.Extensions.Setting;
using H.Providers.Ioc;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace H.Controls.FavoriteBox
{
    [Display(Name = "收藏夹管理", GroupName = SettingGroupNames.GroupSystem, Description = "登录页面设置的信息")]
    public class FavoriteOptions : IocOptionInstance<FavoriteOptions>
    {
        [Browsable(false)]
        public ObservableCollection<FavoriteItem> FavoriteItems { get; set; } = new ObservableCollection<FavoriteItem>();
    }
}
