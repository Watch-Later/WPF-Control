﻿using H.Providers.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Controls.Form
{
    public class FormPresenter : DisplayerViewModelBase
    {
        public FormPresenter(object obj)
        {
            this._value = obj;
        }

        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        private bool _usePropertyView;
        public bool UsePropertyView
        {
            get { return _usePropertyView; }
            set
            {
                _usePropertyView = value;
                RaisePropertyChanged();
            }
        }

    }

    public class ItemsFormPresenter : DisplayerViewModelBase
    {
        private ObservableCollection<object> _objs = new ObservableCollection<object>();

        public ObservableCollection<object> Objs
        {
            get { return _objs; }
            set
            {
                _objs = value;
                RaisePropertyChanged("Objs");
            }
        }
    }
}
