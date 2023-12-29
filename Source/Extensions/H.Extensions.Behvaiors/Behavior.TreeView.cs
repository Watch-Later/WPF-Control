﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using Microsoft.Xaml.Behaviors;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace H.Extensions.Behvaiors
{
    /// <summary> TreeView支持Ctrl Shift多选行为，需要在样式中自定义 IsSelected的效果 </summary>
	public class TreeViewSelectedItemsBindableBehavior : Behavior<TreeView>
    {
        private TreeViewItem _anchorItem;
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList), typeof(TreeViewSelectedItemsBindableBehavior), new PropertyMetadata(null));

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(TreeViewSelectedItemsBindableBehavior),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedChanged));

        public static bool GetIsSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedProperty, value);
        }

        protected override void OnAttached()
        {
            AssociatedObject.AddHandler(TreeViewItem.UnselectedEvent, new RoutedEventHandler(OnTreeViewItemUnselected), true);
            AssociatedObject.AddHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnTreeViewItemSelected), true);
            AssociatedObject.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown), true);
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown));
            AssociatedObject.RemoveHandler(TreeViewItem.UnselectedEvent, new RoutedEventHandler(OnTreeViewItemUnselected));
            AssociatedObject.RemoveHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnTreeViewItemSelected));
            base.OnDetaching();
        }

        private void OnTreeViewItemUnselected(object sender, RoutedEventArgs e)
        {
            if ((Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == ModifierKeys.None)
            {
                SetIsSelected((TreeViewItem)e.OriginalSource, false);
            }
        }

        private void OnTreeViewItemSelected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;

            if (item.DataContext != null && item.DataContext.ToString() == "{DisconnectedItem}")
                return;

            if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) !=
                (ModifierKeys.Shift | ModifierKeys.Control))
            {
                switch ((Keyboard.Modifiers & ModifierKeys.Control))
                {
                    case ModifierKeys.Control:
                        ToggleSelect(item);
                        break;
                    default:
                        if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                            AnchorMultiSelect(item);
                        else
                            SingleSelect(item);
                        break;
                }
            }
        }

        private static TreeView GetTree(TreeViewItem item)
        {
            FrameworkElement currentItem = item;
            while (!(VisualTreeHelper.GetParent(currentItem) is TreeView))
                currentItem = (FrameworkElement)VisualTreeHelper.GetParent(currentItem);

            return (TreeView)VisualTreeHelper.GetParent(currentItem);
        }

        private static void OnSelectedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            TreeViewItem item = (TreeViewItem)sender;
            TreeView tree = GetTree(item);
            Debug.Assert(tree != null);

            TreeViewSelectedItemsBindableBehavior msb = Interaction.GetBehaviors(tree).Single(b => b.GetType() == typeof(TreeViewSelectedItemsBindableBehavior)) as TreeViewSelectedItemsBindableBehavior;
            if (msb != null)
            {
                if (msb.SelectedItems != null)
                {
                    bool isSelected = GetIsSelected(item);
                    if (isSelected)
                        msb.SelectedItems.Add(item.DataContext ?? item);
                    else
                        msb.SelectedItems.Remove(item.DataContext ?? item);
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            Debug.Assert(tree == AssociatedObject);

            // If you press CTRL+A, do a full select.
            if (e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                GetExpandedTreeViewItems(tree)
                    .ToList()
                    .ForEach(tvi => SetIsSelected(tvi, true));

                e.Handled = true;
            }
        }

        private IEnumerable<TreeViewItem> GetExpandedTreeViewItems(ItemsControl container = null)
        {
            if (container == null)
                container = AssociatedObject;

            for (int i = 0; i < container.Items.Count; i++)
            {
                TreeViewItem item = container.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                if (item == null)
                    continue;

                // Hand back this child
                yield return item;

                // Hand back all the children
                foreach (TreeViewItem subItem in GetExpandedTreeViewItems(item))
                    yield return subItem;
            }
        }

        private void AnchorMultiSelect(TreeViewItem newItem)
        {
            if (_anchorItem == null)
            {
                List<TreeViewItem> selectedItems = GetExpandedTreeViewItems().Where(GetIsSelected).ToList();
                _anchorItem = (selectedItems.Count > 0
                                  ? selectedItems[selectedItems.Count - 1]
                                  : GetExpandedTreeViewItems().FirstOrDefault());
                if (_anchorItem == null)
                    return;
            }

            TreeViewItem anchor = _anchorItem;
            IEnumerable<TreeViewItem> items = GetExpandedTreeViewItems();
            bool inSelectionRange = false;

            foreach (TreeViewItem item in items)
            {
                bool isEdge = item == anchor || item == newItem;
                if (isEdge)
                    inSelectionRange = !inSelectionRange;

                SetIsSelected(item, (inSelectionRange || isEdge));
            }
        }

        private void SingleSelect(TreeViewItem item)
        {
            foreach (TreeViewItem selectedItem in GetExpandedTreeViewItems().Where(ti => ti != null))
                SetIsSelected(selectedItem, selectedItem == item);

            _anchorItem = item;
        }

        private void ToggleSelect(TreeViewItem item)
        {
            SetIsSelected(item, !GetIsSelected(item));
            if (_anchorItem == null)
                _anchorItem = item;
        }
    }


    public class TreeViewSelectedItemBindableBehavior : Behavior<TreeView>
    {
        #region SelectedItem Property

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(TreeViewSelectedItemBindableBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var item = e.NewValue as TreeViewItem;
            if (item != null)
            {
                item.SetValue(TreeViewItem.IsSelectedProperty, true);
            }
        }

        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SelectedItem = e.NewValue;
        }
    }

    public class TreeViewSelectNoneOnMouseDownBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.MouseDown += AssociatedObject_MouseDown;
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(this.AssociatedObject);
            var item = this.AssociatedObject.HitTest<TreeViewItem>(point);
            if (item == null)
                this.AssociatedObject.SelectNone();

        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDown -= AssociatedObject_MouseDown;

        }
    }
}


