﻿using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace H.Extensions.Behvaiors
{
    public class DataGridAutoColumnBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratedColumns += AssociatedObject_AutoGeneratedColumns;
        }

        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }


        public string UsePropertyNames
        {
            get { return (string)GetValue(UsePropertyNamesProperty); }
            set { SetValue(UsePropertyNamesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsePropertyNamesProperty =
            DependencyProperty.Register("UsePropertyNames", typeof(string), typeof(DataGridAutoColumnBehavior), new FrameworkPropertyMetadata(default(string), (d, e) =>
            {
                DataGridAutoColumnBehavior control = d as DataGridAutoColumnBehavior;

                if (control == null) return;

                if (e.OldValue is string o)
                {

                }

                if (e.NewValue is string n)
                {

                }
                control.GenerateColumns();
            }));


        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Type), typeof(DataGridAutoColumnBehavior), new FrameworkPropertyMetadata(default(Type), (d, e) =>
            {
                DataGridAutoColumnBehavior control = d as DataGridAutoColumnBehavior;

                if (control == null) return;

                if (e.OldValue is Type o)
                {

                }

                if (e.NewValue is Type n)
                {

                }
                control.GenerateColumns();
            }));

        /// <summary>
        /// Model.{0}
        /// </summary>
        public string BindingPath
        {
            get { return (string)GetValue(BindingPathProperty); }
            set { SetValue(BindingPathProperty, value); }
        }


        public static readonly DependencyProperty BindingPathProperty =
            DependencyProperty.Register("BindingPath", typeof(string), typeof(DataGridAutoColumnBehavior), new FrameworkPropertyMetadata("{0}", (d, e) =>
            {
                DataGridAutoColumnBehavior control = d as DataGridAutoColumnBehavior;

                if (control == null) return;

                if (e.OldValue is string o)
                {

                }

                if (e.NewValue is string n)
                {

                }

                control.GenerateColumns();
            }));

        public DataGridLength DataGridLength
        {
            get { return (DataGridLength)GetValue(DataGridLengthProperty); }
            set { SetValue(DataGridLengthProperty, value); }
        }


        public static readonly DependencyProperty DataGridLengthProperty =
            DependencyProperty.Register("DataGridLength", typeof(DataGridLength), typeof(DataGridAutoColumnBehavior), new FrameworkPropertyMetadata(DataGridLength.Auto, (d, e) =>
            {
                DataGridAutoColumnBehavior control = d as DataGridAutoColumnBehavior;

                if (control == null) return;

                if (e.OldValue is DataGridLength o)
                {

                }

                if (e.NewValue is DataGridLength n)
                {

                }
                control.GenerateColumns();

            }));


        private void AssociatedObject_AutoGeneratedColumns(object sender, EventArgs e)
        {
            GenerateColumns();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratedColumns -= AssociatedObject_AutoGeneratedColumns;
        }

        public ObservableCollection<DataGridColumn> HomeColumns { get; } = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> EndColumns { get; } = new ObservableCollection<DataGridColumn>();

        private void GenerateColumns()
        {
            this.DelayInvoke(() =>
            {
                GenerateColunms(AssociatedObject);
            });
        }

        protected virtual void GenerateColunms(DataGrid dataGrid)
        {
            if (dataGrid == null)
                return;
            if (dataGrid.IsInitialized == false)
                return;
            dataGrid.Columns.Clear();
            foreach (DataGridColumn item in HomeColumns)
            {
                dataGrid.Columns.Add(item);
            }
            if (Type == null)
                return;
            PropertyInfo[] ps = Type.GetProperties();
            foreach (PropertyInfo p in ps)
            {
                BrowsableAttribute browsable = p.GetCustomAttribute<BrowsableAttribute>();
                if (browsable?.Browsable == false)
                    continue;

                if (!string.IsNullOrEmpty(this.UsePropertyNames))
                {
                    var names = this.UsePropertyNames.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (names.Count() > 0 && !names.Any(x => x == p.Name))
                        continue;
                }
                DisplayAttribute display = p.GetCustomAttribute<DisplayAttribute>();
                ReadOnlyAttribute readOnly = p.GetCustomAttribute<ReadOnlyAttribute>();
                DataGridColumnAttribute columnAttribute = p.GetCustomAttribute<DataGridColumnAttribute>();
                DataGridColumn column = columnAttribute == null ? GetDataGridColumn(p)
                    : columnAttribute.GetDataGridColumn(p);
                column.Header = display?.Name ?? p.Name;
                if (column is DataGridBoundColumn bound)
                {
                    Binding binding = new Binding();
                    string path = string.Format(BindingPath, string.Format(columnAttribute?.PropertyPath ?? "{0}", p.Name));
                    binding.Path = new PropertyPath(path);
                    binding.Mode = readOnly?.IsReadOnly == true ? BindingMode.OneWay : BindingMode.TwoWay;
                    bound.Binding = binding;
                }
                dataGrid.Columns.Add(column);
            }
            foreach (DataGridColumn item in EndColumns)
            {
                dataGrid.Columns.Add(item);
            }

        }

        public DataGridColumn GetDataGridColumn(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(bool))
            {
                return new DataGridCheckBoxColumn() { Width = DataGridLength };
            }
            else if (propertyInfo.PropertyType.IsEnum)
            {
                return new DataGridComboBoxColumn() { Width = DataGridLength };
            }
            else
            {
                return new DataGridTextColumn() { Width = DataGridLength };
            }
        }
    }
}
