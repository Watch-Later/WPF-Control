﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase


using H.Extensions.TypeConverter;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace H.Presenters.Design
{
    public class DefinitionGrid : GridBase
    {
        public static ComponentResourceKey DefaultKey => new ComponentResourceKey(typeof(DefinitionGrid), "S.DefinitionGrid.Default");
        static DefinitionGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DefinitionGrid), new FrameworkPropertyMetadata(typeof(DefinitionGrid)));
        }
        [TypeConverter(typeof(ObservableCollectionTypeConverter<GridLength, GridLengthConverter>))]
        public ObservableCollection<GridLength> Rows
        {
            get { return (ObservableCollection<GridLength>)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(ObservableCollection<GridLength>), typeof(DefinitionGrid), new FrameworkPropertyMetadata(new ObservableCollection<GridLength>(), (d, e) =>
            {
                DefinitionGrid control = d as DefinitionGrid;

                if (control == null) return;

                if (e.OldValue is ObservableCollection<GridLength> o)
                {

                }

                if (e.NewValue is ObservableCollection<GridLength> n)
                {

                }
                control.Refresh();
            }));

        [TypeConverter(typeof(ObservableCollectionTypeConverter<GridLength, GridLengthConverter>))]
        public ObservableCollection<GridLength> Columns
        {
            get { return (ObservableCollection<GridLength>)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(ObservableCollection<GridLength>), typeof(DefinitionGrid), new FrameworkPropertyMetadata(new ObservableCollection<GridLength>(), (d, e) =>
            {
                DefinitionGrid control = d as DefinitionGrid;

                if (control == null) return;

                if (e.OldValue is ObservableCollection<GridLength> o)
                {

                }

                if (e.NewValue is ObservableCollection<GridLength> n)
                {

                }
                control.Refresh();
            }));

        protected override void Refresh()
        {
            RowDefinitions.Clear();
            ColumnDefinitions.Clear();

            foreach (var item in Rows)
            {
                RowDefinitions.Add(new RowDefinition() { Height = item, MinHeight = MinRowHeight });
            }
            foreach (var item in Columns)
            {
                ColumnDefinitions.Add(new ColumnDefinition() { Width = item });
            }
        }
    }
}
