﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace H.Extensions.StoryBoard
{
    public static class StoryboardSetting
    {
        [DefaultValue(20)]
        [Range(0, 60)]
        public static int DesiredFrameRate { get; set; } = 25;

    }
}
