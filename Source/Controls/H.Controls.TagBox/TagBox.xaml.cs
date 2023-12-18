﻿using H.Providers.Ioc;
using H.Providers.Mvvm;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            var service = Ioc.GetService<ITagService>();
            if (service == null)
                return;
            service.Load();
            this.ItemsSource = service?.Collection;
        }
        private bool _flag = false;
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            var tags = this.SelectedItems.OfType<ITag>();
            this._flag = true;
            this.Tags = string.Join(",", tags.Select(x => x.Name));
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
                        var find = TagOptions.Instance.Tags.FirstOrDefault(x => x.Name == value);
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

    public class CreateTagCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            var service = Ioc.GetService<ITagService>();
            var tag = service.Create();
            var r = await IocMessage.Form.ShowEdit(tag);
            if (r != true)
                return;
            service.Add(tag);
            service.Save(out string message);
        }

        public override bool CanExecute(object parameter)
        {
            return Ioc.Exist<ITagService>();
        }
    }

    public class ManageTagCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            var tag = new TagsPresenter();
            await IocMessage.Dialog.Show(tag);
        }

        public override bool CanExecute(object parameter)
        {
            return Ioc.Exist<ITagService>();
        }
    }

    public class TagsPresenter
    {

    }
}
