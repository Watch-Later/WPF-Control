﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace H.Extensions.ValueConverter
{
    public class GetTypeAttributeConverter : MarkupValueConverterBase
    {
        public Type AttributeType { get; set; } = typeof(DescriptionAttribute);
        public int Index { get; set; } = 0;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            Type type = value is Type t ? t : value.GetType();
            var attributes = type.GetCustomAttributes(AttributeType, false);
            if (attributes == null || attributes.Count() == 0)
                return DependencyProperty.UnsetValue;
            return attributes[0];

        }
    }
}
