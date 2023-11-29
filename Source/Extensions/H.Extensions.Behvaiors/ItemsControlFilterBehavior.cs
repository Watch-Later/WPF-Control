﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using H.Providers.Ioc;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace H.Extensions.Behvaiors
{
    public class ItemsControlFilterBehavior : Behavior<ItemsControl>
    {
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IEnumerable), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;
                if (control == null)
                    return;
                if (e.OldValue is INotifyCollectionChanged o)
                    o.CollectionChanged -= control.CollectionChanged;
                if (e.NewValue is INotifyCollectionChanged n)
                    n.CollectionChanged += control.CollectionChanged;
                control.RefreshData();
            }));

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.RefreshData();
        }

        public IFilter Filter
        {
            get { return (IFilter)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter1
        {
            get { return (IFilter)GetValue(Filter1Property); }
            set { SetValue(Filter1Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter1Property =
            DependencyProperty.Register("Filter1", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter2
        {
            get { return (IFilter)GetValue(Filter2Property); }
            set { SetValue(Filter2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter2Property =
            DependencyProperty.Register("Filter2", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter3
        {
            get { return (IFilter)GetValue(Filter3Property); }
            set { SetValue(Filter3Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter3Property =
            DependencyProperty.Register("Filter3", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IDisplayFilter Filter4
        {
            get { return (IDisplayFilter)GetValue(Filter4Property); }
            set { SetValue(Filter4Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter4Property =
            DependencyProperty.Register("Filter4", typeof(IDisplayFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IDisplayFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter5
        {
            get { return (IFilter)GetValue(Filter5Property); }
            set { SetValue(Filter5Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter5Property =
            DependencyProperty.Register("Filter5", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter6
        {
            get { return (IFilter)GetValue(Filter6Property); }
            set { SetValue(Filter6Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter6Property =
            DependencyProperty.Register("Filter6", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter7
        {
            get { return (IFilter)GetValue(Filter7Property); }
            set { SetValue(Filter7Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter7Property =
            DependencyProperty.Register("Filter7", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter8
        {
            get { return (IFilter)GetValue(Filter8Property); }
            set { SetValue(Filter8Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter8Property =
            DependencyProperty.Register("Filter8", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));


        public IFilter Filter9
        {
            get { return (IFilter)GetValue(Filter9Property); }
            set { SetValue(Filter9Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Filter9Property =
            DependencyProperty.Register("Filter9", typeof(IFilter), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IFilter), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IFilter o)
                {

                }

                if (e.NewValue is IFilter n)
                {

                }
                control.RefreshData();
            }));



        public IOrder Order
        {
            get { return (IOrder)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));


        public IOrder Order2
        {
            get { return (IOrder)GetValue(Order2Property); }
            set { SetValue(Order2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Order2Property =
            DependencyProperty.Register("Order2", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));


        public IOrder Order1
        {
            get { return (IOrder)GetValue(Order1Property); }
            set { SetValue(Order1Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Order1Property =
            DependencyProperty.Register("Order1", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));


        public IOrder Order3
        {
            get { return (IOrder)GetValue(Order3Property); }
            set { SetValue(Order3Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Order3Property =
            DependencyProperty.Register("Order3", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));


        public IOrder Order4
        {
            get { return (IOrder)GetValue(Order4Property); }
            set { SetValue(Order4Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Order4Property =
            DependencyProperty.Register("Order4", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));


        public IOrder Order5
        {
            get { return (IOrder)GetValue(Order5Property); }
            set { SetValue(Order5Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Order5Property =
            DependencyProperty.Register("Order5", typeof(IOrder), typeof(ItemsControlFilterBehavior), new FrameworkPropertyMetadata(default(IOrder), (d, e) =>
            {
                ItemsControlFilterBehavior control = d as ItemsControlFilterBehavior;

                if (control == null) return;

                if (e.OldValue is IOrder o)
                {

                }

                if (e.NewValue is IOrder n)
                {

                }
                control.RefreshData();
            }));



        private IEnumerable<IFilter> GetFilters()
        {
            yield return this.Filter;
            yield return this.Filter1;
            yield return this.Filter2;
            yield return this.Filter3;
            yield return this.Filter4;
            yield return this.Filter5;
            yield return this.Filter6;
            yield return this.Filter7;
            yield return this.Filter8;
            yield return this.Filter9;
        }
        private IEnumerable<IOrder> GetOrders()
        {
            yield return this.Order;
            yield return this.Order1;
            yield return this.Order2;
            yield return this.Order3;
            yield return this.Order4;
            yield return this.Order5;
        }

        private void RefreshData()
        {
            if (this.ItemsSource == null)
                return;
            if (this.AssociatedObject == null)
                return;
            var filters = this.GetFilters().Where(x => x != null);
            var source = filters.Count() == 0 ? this.ItemsSource
                : this.ItemsSource.OfType<object>().Where(x => filters.All(l => l.IsMatch(x)));
            var orders = this.GetOrders().ToList();
            foreach (var item in orders)
            {
                if (item == null)
                    continue;
                source = item.Where(source);
            }
            this.AssociatedObject.ItemsSource = source;
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.RefreshData();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }

}