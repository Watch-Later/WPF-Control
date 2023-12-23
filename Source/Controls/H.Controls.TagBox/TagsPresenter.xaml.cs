﻿using H.Providers.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace H.Controls.TagBox
{
    public class TagsPresenter : NotifyPropertyChangedBase
    {
        private ObservableCollection<ITag> _collection = new ObservableCollection<ITag>();
        /// <summary> 说明  </summary>
        public ObservableCollection<ITag> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged();
            }
        }

    }
}
