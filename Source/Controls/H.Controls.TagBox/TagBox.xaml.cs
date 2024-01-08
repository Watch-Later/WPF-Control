﻿using H.Providers.Mvvm;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace H.Controls.TagBox
{
    public class TagBox : ListBox
    {
        static TagBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TagBox), new FrameworkPropertyMetadata(typeof(TagBox)));
        }

        public TagBox()
        {
            IocTagService.Instance.CollectionChanged += (l, k) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.RefreshData();
                });

            };
        }


        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(TagBox), new FrameworkPropertyMetadata(default(string), (d, e) =>
            {
                TagBox control = d as TagBox;

                if (control == null) return;

                if (e.OldValue is string o)
                {

                }

                if (e.NewValue is string n)
                {

                }
                control.RefreshData();
            }));


        private void RefreshData()
        {
            var service = Ioc.GetService<ITagService>();
            this.ItemsSource = service?.Collection.Where(x => x.GroupName == this.GroupName).Select(x => new ModelViewModel<ITag>(x));
            //this.Items.Filter = x =>
            //{
            //    if (x is ITag tag)
            //    {
            //        return string.IsNullOrEmpty(this.SearchText) || tag.Name.Contains(this.SearchText);
            //    }
            //    return false;
            //};

            foreach (var item in this.ItemsSource.OfType<ModelViewModel<ITag>>())
            {
                item.Visible = string.IsNullOrEmpty(this.SearchText) || item.Model.Name.Contains(this.SearchText);
            }
        }

        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(TagBox), new FrameworkPropertyMetadata(default(string), (d, e) =>
            {
                TagBox control = d as TagBox;

                if (control == null) return;

                if (e.OldValue is string o)
                {

                }

                if (e.NewValue is string n)
                {

                }
                //control.RefreshData();
            }));


        private bool _flag = false;
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            var tags = this.SelectedItems.OfType<ModelViewModel<ITag>>();
            this._flag = true;
            this.Tags = string.Join(",", tags.Select(x => x.Model.Name));
            this.OnTagChanged();
            this._flag = false;
        }

        public string Tags
        {
            get { return (string)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(string), typeof(TagBox), new FrameworkPropertyMetadata(string.Empty, // default value
                                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | // Flags
                                           FrameworkPropertyMetadataOptions.Journal, (d, e) =>
            {
                TagBox control = d as TagBox;
                if (control == null)
                    return;
                if (control._flag)
                    return;
                if (control.SelectionMode == SelectionMode.Single)
                    return;
                control.SelectedItems.Clear();
                if (e.OldValue is string o)
                {

                }

                if (e.NewValue is string n)
                {
                    var values = n.Split(TagOptions.Instance.SplitChars.ToCharArray());

                    foreach (var value in values)
                    {
                        var find = control.ItemsSource.OfType<ModelViewModel<ITag>>().FirstOrDefault(x => x.Model.Name == value);
                        if (find == null)
                            continue;
                        control.SelectedItems.Add(find);
                    }
                }
            }));


        //声明和注册路由事件
        public static readonly RoutedEvent TagChangedRoutedEvent =
            EventManager.RegisterRoutedEvent("TagChanged", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(TagBox));
        //CLR事件包装
        public event RoutedEventHandler TagChanged
        {
            add { this.AddHandler(TagChangedRoutedEvent, value); }
            remove { this.RemoveHandler(TagChangedRoutedEvent, value); }
        }

        //激发路由事件,借用Click事件的激发方法

        protected void OnTagChanged()
        {
            RoutedEventArgs args = new RoutedEventArgs(TagChangedRoutedEvent, this);
            this.RaiseEvent(args);
        }


    }
}
