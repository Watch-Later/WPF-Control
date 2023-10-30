﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System.Windows;

namespace H.Controls.PropertyGrid
{
    public class ItemAddingEventArgs : CancelRoutedEventArgs
    {
        #region Constructor

        public ItemAddingEventArgs(RoutedEvent itemAddingEvent, object itemAdding)
          : base(itemAddingEvent)
        {
            Item = itemAdding;
        }

        #endregion

        #region Properties

        #region Item Property

        public object Item
        {
            get;
            set;
        }

        #endregion

        #endregion //Properties
    }
}
