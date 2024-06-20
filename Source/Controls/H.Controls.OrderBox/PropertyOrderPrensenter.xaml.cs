﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using H.Providers.Ioc;
using H.Providers.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace H.Controls.OrderBox
{
    [Display(Name = "设置规则")]
    public class PropertyOrderPrensenter : DisplayBindableBase, IOrderable, IMetaSetting
    {
        public PropertyOrderPrensenter()
        {

        }

        private string _id;
        [Browsable(false)]
        public override string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public PropertyOrderPrensenter(Type modelTyle, Func<PropertyInfo, bool> predicate = null)
        {
            ObservableCollection<PropertyInfo> ps = modelTyle.GetProperties().Where(x => x.PropertyType.IsPrimitive || x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(string)).ToObservable();
            if (predicate != null)
                this.Properties = ps.Where(predicate).ToObservable();
            else
                this.Properties = ps.ToObservable();
        }

        private ObservableCollection<PropertyOrder> _conditions = new ObservableCollection<PropertyOrder>();
        public ObservableCollection<PropertyOrder> Conditions
        {
            get { return _conditions; }
            set
            {
                _conditions = value;
                RaisePropertyChanged();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public RelayCommand AddConditionCommand => new RelayCommand(l =>
        {
            PropertyInfo first = this.Properties.FirstOrDefault();
            PropertyOrder Order = new PropertyOrder(first);
            this.Conditions.Add(Order);
        });
        [JsonIgnore]
        [XmlIgnore]
        public RelayCommand ClearConditionCommand => new RelayCommand(l =>
        {
            this.Conditions.Clear();
        }, l => this.Conditions.Count > 0);
        [JsonIgnore]
        [XmlIgnore]
        public RelayCommand SaveCommand => new RelayCommand(l =>
        {
            this.Save(out string message);
        });

        private ObservableCollection<PropertyInfo> _properties = new ObservableCollection<PropertyInfo>();
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<PropertyInfo> Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                RaisePropertyChanged();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public IMetaSettingService MetaSettingService => new JsonMetaSettingService();

        public bool Save(out string message)
        {
            message = null;
            if (string.IsNullOrEmpty(this.ID))
            {
                message = "ID为空";
                return false;
            }
            this.MetaSettingService?.Serilize(this, this.ID);
            return true;
        }
        private bool _isLoaded = false;
        public void Load()
        {
            if (_isLoaded)
                return;
            if (string.IsNullOrEmpty(this.ID))
                return;
            PropertyOrderPrensenter find = this.MetaSettingService?.Deserilize<PropertyOrderPrensenter>(this.ID);
            if (find == null)
                return;

            foreach (PropertyOrder item in find.Conditions)
            {
                PropertyInfo propertyInfo = this.Properties.FirstOrDefault(x => x.Name == item.PropertyName);
                PropertyOrder pc = new PropertyOrder(propertyInfo);
                this.Conditions.Add(pc);
            }
            _isLoaded = true;
        }

        public IEnumerable Where(IEnumerable from)
        {
            Func<object, object> convert = x => x is IModelBindable m ? m.GetModel() : x;
            List<PropertyOrder> selecteds = this.Conditions.Where(x => x.IsSelected).ToList();
            if (selecteds.Count == 0)
                return from;
            PropertyOrder first = selecteds[0];
            IOrderedEnumerable<object> result = first.UseDesc ?
                from.OfType<object>().OrderByDescending(x => first.PropertyInfo.GetValue(convert(x))) :
                from.OfType<object>().OrderBy(x => first.PropertyInfo.GetValue(convert(x)));
            if (selecteds.Count == 1)
                return result;

            for (int i = 1; i < selecteds.Count; i++)
            {
                PropertyOrder item = selecteds[i];
                result = item.UseDesc ? result.ThenByDescending(x => item.PropertyInfo.GetValue(convert(x))) :
                     result.ThenBy(x => item.PropertyInfo.GetValue(convert(x)));
            }
            return result;
        }
    }
}
