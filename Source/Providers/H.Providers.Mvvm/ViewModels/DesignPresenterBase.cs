﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using H.Providers.Mvvm;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Serialization;

namespace H.Providers.Mvvm
{
    public interface IDesignPresenterBase
    {
        Brush Background { get; set; }
        Brush BorderBrush { get; set; }
        Thickness BorderThickness { get; set; }
        int Column { get; set; }
        int ColumnSpan { get; set; }
        RelayCommand DeleteCommand { get; }
        double Height { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        HorizontalAlignment HorizontalContentAlignment { get; set; }
        bool IsEnabled { get; set; }
        bool IsMouseOver { get; set; }
        bool IsSelected { get; set; }
        bool IsVisible { get; set; }
        Thickness Margin { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
        double Opacity { get; set; }
        Thickness Padding { get; set; }
        int Row { get; set; }
        int RowSpan { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        VerticalAlignment VerticalContentAlignment { get; set; }
        double Width { get; set; }
    }

    public abstract class DesignPresenterBase : DisplayerViewModelBase, IDesignPresenterBase
    {
        private bool _isSelected;
        [Browsable(false)]
        [XmlIgnore]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        private bool _isMouseOver;
        [Browsable(false)]
        [XmlIgnore]
        public bool IsMouseOver
        {
            get { return _isMouseOver; }
            set
            {
                _isMouseOver = value;
                RaisePropertyChanged();
            }
        }


        private double _height = double.NaN;
        [DefaultValue(double.NaN)]
        [Display(Name = "高", GroupName = "常用,布局")]
        [TypeConverter(typeof(LengthConverter))]
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged();
            }
        }

        private double _width = double.NaN;
        [DefaultValue(double.NaN)]
        [Display(Name = "宽", GroupName = "常用,布局")]
        [TypeConverter(typeof(LengthConverter))]
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged();
            }
        }

        private double _minHeight = double.NaN;
        [DefaultValue(double.NaN)]
        [Display(Name = "最小高度", GroupName = "布局")]
        [TypeConverter(typeof(LengthConverter))]
        public double MinHeight
        {
            get { return _minHeight; }
            set
            {
                _minHeight = value;
                RaisePropertyChanged();
            }
        }

        private double _minWidth = double.NaN;
        [DefaultValue(double.NaN)]
        [Display(Name = "最小宽度", GroupName = "布局")]
        [TypeConverter(typeof(LengthConverter))]
        public double MinWidth
        {
            get { return _minWidth; }
            set
            {
                _minWidth = value;
                RaisePropertyChanged();
            }
        }

        private Thickness _margin = new Thickness();
        [Display(Name = "外部间距", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public Thickness Margin
        {
            get { return _margin; }
            set
            {
                _margin = value;
                RaisePropertyChanged();
            }
        }

        private Thickness _padding;
        [Display(Name = "内部间距", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public Thickness Padding
        {
            get { return _padding; }
            set
            {
                _padding = value;
                RaisePropertyChanged();
            }
        }

        private HorizontalAlignment _horizontalAlignment = HorizontalAlignment.Stretch;
        [Display(Name = "水平对齐", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get { return _horizontalAlignment; }
            set
            {
                _horizontalAlignment = value;
                RaisePropertyChanged();
            }
        }

        private HorizontalAlignment _horizontalContentAlignment;
        [Display(Name = "水平内容对齐", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public HorizontalAlignment HorizontalContentAlignment
        {
            get { return _horizontalContentAlignment; }
            set
            {
                _horizontalContentAlignment = value;
                RaisePropertyChanged();
            }
        }

        private VerticalAlignment _verticalAlignment = VerticalAlignment.Stretch;
        [Display(Name = "垂直对齐", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public VerticalAlignment VerticalAlignment
        {
            get { return _verticalAlignment; }
            set
            {
                _verticalAlignment = value;
                RaisePropertyChanged();
            }
        }

        private VerticalAlignment _verticalContentAlignment;
        [Display(Name = "垂直内部对齐", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public VerticalAlignment VerticalContentAlignment
        {
            get { return _verticalContentAlignment; }
            set
            {
                _verticalContentAlignment = value;
                RaisePropertyChanged();
            }
        }


        private Brush _background;
        [Display(Name = "背景颜色", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public Brush Background
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged();
            }
        }

        private Brush _borderBrush;
        [Display(Name = "边框颜色", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public Brush BorderBrush
        {
            get { return _borderBrush; }
            set
            {
                _borderBrush = value;
                RaisePropertyChanged();
            }
        }

        private Thickness _borderThickness;
        [Display(Name = "边框粗细", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public Thickness BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value;
                RaisePropertyChanged();
            }
        }

        private double _opacity = 1;
        [DefaultValue(1.0)]
        [Display(Name = "透明度", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public double Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                RaisePropertyChanged();
            }
        }

        private bool _isVisible = true;
        [Display(Name = "可见", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged();
            }
        }

        private bool _isEnabled = true;
        [Display(Name = "可用", GroupName = "样式")]
        /// <summary> 说明  </summary>
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged();
            }
        }


        private int _row;
        [Display(Name = "行", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public int Row
        {
            get { return _row; }
            set
            {
                _row = value;
                RaisePropertyChanged();
            }
        }


        private int _column;
        [Display(Name = "列", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public int Column
        {
            get { return _column; }
            set
            {
                _column = value;
                RaisePropertyChanged();
            }
        }


        private int _rowSpan;
        [Display(Name = "行跨距", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public int RowSpan
        {
            get { return _rowSpan; }
            set
            {
                _rowSpan = value;
                RaisePropertyChanged();
            }
        }

        private int _columnSpan;
        [Display(Name = "列跨距", GroupName = "布局")]
        /// <summary> 说明  </summary>
        public int ColumnSpan
        {
            get { return _columnSpan; }
            set
            {
                _columnSpan = value;
                RaisePropertyChanged();
            }
        }

        [Displayer(Name = "删除")]
        public RelayCommand DeleteCommand => new RelayCommand((s, e) =>
        {
            Delete(e);
        });

        protected virtual void Delete(object e)
        {
            if (e is ContentControl project)
            {
                Adorner adorner = GetParent<Adorner>(project);
                ItemsControl source = GetParent<ItemsControl>(adorner.AdornedElement);
                GetItemsSource<IList>(source).Remove(project.Content);
            }
        }

        private T GetItemsSource<T>(UIElement element) where T : IEnumerable
        {
            if (element is ItemsControl items)
                return (T)items.ItemsSource;
            return default;
        }

        private T GetParent<T>(DependencyObject element) where T : DependencyObject
        {
            if (element == null) return null;
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            while (parent != null && !(parent is T))
            {
                DependencyObject newVisualParent = VisualTreeHelper.GetParent(parent);
                if (newVisualParent != null)
                {
                    parent = newVisualParent;
                }
                else
                {
                    if (parent is FrameworkElement)
                    {
                        parent = (parent as FrameworkElement).Parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return parent as T;
        }
    }
}
