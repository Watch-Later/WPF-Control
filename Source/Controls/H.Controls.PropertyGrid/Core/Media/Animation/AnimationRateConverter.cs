﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace H.Controls.PropertyGrid.Media.Animation
{
    public class AnimationRateConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext td, Type t)
        {
            return (t == typeof(string))
                || (t == typeof(double))
                || (t == typeof(int))
                || (t == typeof(TimeSpan));
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(InstanceDescriptor))
                || (destinationType == typeof(string))
                || (destinationType == typeof(double))
                || (destinationType == typeof(TimeSpan));
        }

        public override object ConvertFrom(
          ITypeDescriptorContext td,
          CultureInfo cultureInfo,
          object value)
        {
            Type valueType = value.GetType();
            if (value is string)
            {
                string stringValue = value as string;
                if ((value as string).Contains(":"))
                {
                    TimeSpan duration = TimeSpan.Zero;
                    duration = (TimeSpan)TypeDescriptor.GetConverter(duration).ConvertFrom(td, cultureInfo, value);
                    return new AnimationRate(duration);
                }
                else
                {
                    double speed = 0;
                    speed = (double)TypeDescriptor.GetConverter(speed).ConvertFrom(td, cultureInfo, value);
                    return new AnimationRate(speed);
                }
            }
            else if (valueType == typeof(double))
            {
                return (AnimationRate)(double)value;
            }
            else if (valueType == typeof(int))
            {
                return (AnimationRate)(int)value;
            }
            else // TimeSpan
            {
                return (AnimationRate)(TimeSpan)value;
            }
        }

        public override object ConvertTo(
          ITypeDescriptorContext context,
          CultureInfo cultureInfo,
          object value,
          Type destinationType)
        {
            if (destinationType != null && value is AnimationRate)
            {
                AnimationRate rateValue = (AnimationRate)value;

                if (destinationType == typeof(InstanceDescriptor))
                {
                    MemberInfo mi;
                    if (rateValue.HasDuration)
                    {
                        mi = typeof(AnimationRate).GetConstructor(new Type[] { typeof(TimeSpan) });
                        return new InstanceDescriptor(mi, new object[] { rateValue.Duration });
                    }
                    else if (rateValue.HasSpeed)
                    {
                        mi = typeof(AnimationRate).GetConstructor(new Type[] { typeof(double) });
                        return new InstanceDescriptor(mi, new object[] { rateValue.Speed });
                    }
                }
                else if (destinationType == typeof(string))
                {
                    return rateValue.ToString();
                }
                else if (destinationType == typeof(double))
                {
                    return rateValue.HasSpeed ? rateValue.Speed : 0.0d;
                }
                else if (destinationType == typeof(TimeSpan))
                {
                    return rateValue.HasDuration ? rateValue.Duration : TimeSpan.FromSeconds(0);
                }
            }

            return base.ConvertTo(context, cultureInfo, value, destinationType);
        }
    }
}
