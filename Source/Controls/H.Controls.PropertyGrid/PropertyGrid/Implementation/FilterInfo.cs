﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace H.Controls.PropertyGrid
{
    internal struct FilterInfo
    {
        public string InputString;
        public Predicate<object> Predicate;
    }
}
