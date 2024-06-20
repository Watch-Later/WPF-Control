﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using H.Providers.Mvvm;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace H.Controls.FilterBox
{
    public class PropertyConfidtion : Bindable, IConditionable, IPropertyConfidtion
    {
        public PropertyConfidtion()
        {

        }

        public PropertyConfidtion(PropertyInfo propertyInfo)
        {
            this.Filter = FilterFactory.Create(propertyInfo, null) as IPropertyFilter;
        }

        private IPropertyFilter _filter;
        public IPropertyFilter Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                RaisePropertyChanged();
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public RelayCommand SelectionChangedCommand => new RelayCommand(l =>
        {
            if (l is SelectionChangedEventArgs arg)
            {
                if (arg.AddedItems[0] is PropertyInfo info)
                    this.Filter = FilterFactory.Create(info, null) as IPropertyFilter;

            }
        });

        public bool IsMatch(object obj)
        {
            if (obj == null)
                return false;
            if (obj is IModelBindable mv)
                return this.Filter.IsMatch(mv.GetModel());
            return this.Filter.IsMatch(obj);
        }
    }
}
