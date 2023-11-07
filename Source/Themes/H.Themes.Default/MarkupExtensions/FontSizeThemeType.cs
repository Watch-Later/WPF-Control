﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using H.Extensions.TypeConverter;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace H.Themes.Default
{
    [TypeConverter(typeof(DisplayEnumConverter))]
    public enum FontSizeThemeType
    {
        [Display(Name = "常规")]
        Default = 0,
        [Display(Name = "大")]
        Large,
        [Display(Name = "小")]
        Small
    }
}
