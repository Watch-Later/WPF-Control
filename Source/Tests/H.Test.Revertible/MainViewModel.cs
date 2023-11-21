﻿using H.Extensions.Revertible;
using H.Extensions.ViewModel;
using H.Providers.Ioc;
using H.Providers.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Test.Revertible
{
    internal class MainViewModel : RevertiblePropertyChangedBase
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                string oldValue = _value;
                var persenter = new PropertyChangedRevertiblePrensenter<string>(nameof(Value), _value, value);
                IocRevertible.Commit(() =>
                {
                    _value = value;
                    RaisePropertyChanged();

                }, () =>
                    {
                        _value = oldValue;
                        RaisePropertyChanged();
                    }, null, persenter);
            }
        }

        private string _value1;
        /// <summary> 说明  </summary>
        public string Value1
        {
            get { return _value1; }
            set
            {
                this.SetRevertiableProperty(v => _value1 = v, _value1, value);
            }
        }

    }
}
