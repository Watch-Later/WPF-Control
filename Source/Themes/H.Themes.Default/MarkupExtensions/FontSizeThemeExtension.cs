﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;

namespace H.Themes.Default
{
    public class FontSizeThemeExtension : ThemeExtensionBase
    {
        public ThemeType Type { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetResource("FontSizes", Type.ToString());
        }
    }
}
