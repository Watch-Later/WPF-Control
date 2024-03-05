﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace H.Extensions.Behvaiors
{

    public class ButtonRemoveCheckedItemBehavior : ButtonBehaviorBase
    {
        protected ListBox ListBox => ItemsControl as ListBox;
        protected override void OnClick()
        {
            if (ListBox == null)
                return;
            List<object> objs = new List<object>();
            foreach (object item in ListBox.Items)
            {
                DependencyObject find = ListBox.ItemContainerGenerator.ContainerFromItem(item);
                if (find is ListBoxItem listBoxItem)
                {
                    if (!listBoxItem.IsSelected)
                        continue;
                    objs.Add(item);
                }
            }
            if (ItemsSource is IList list)
            {
                foreach (object item in objs)
                {
                    list.Remove(item);
                }
            }
        }
    }

}