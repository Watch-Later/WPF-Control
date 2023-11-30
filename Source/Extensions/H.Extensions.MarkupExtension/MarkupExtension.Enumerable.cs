﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Linq;

namespace H.Extensions.MarkupExtension
{
    public class GetRangeExtension : System.Windows.Markup.MarkupExtension
    {
        public int Start { get; set; }

        public int Count { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(this.Start, this.Count).ToList();
        }
    }
}
