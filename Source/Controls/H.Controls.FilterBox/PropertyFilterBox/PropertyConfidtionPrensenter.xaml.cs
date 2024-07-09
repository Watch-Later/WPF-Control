﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using H.Extensions.XmlSerialize;
using H.Services.Common;
using H.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace H.Controls.FilterBox
{

    [Display(Name = "设置条件")]
    public class PropertyConfidtionPrensenter : DisplayBindableBase, IConditionable, IMetaSetting
    {
        public PropertyConfidtionPrensenter()
        {

        }

        public PropertyConfidtionPrensenter(Type modelTyle, Func<PropertyInfo, bool> predicate = null)
        {
            ObservableCollection<PropertyInfo> ps = modelTyle.GetProperties().Where(x => x.PropertyType.IsPrimitive || x.PropertyType == typeof(DateTime) || x.PropertyType == typeof(string)).ToObservable();
            if (predicate != null)
                this.Properties = ps.Where(predicate).ToObservable();
            else
                this.Properties = ps.ToObservable();
        }

        private ObservableCollection<IPropertyConfidtion> _conditions = new ObservableCollection<IPropertyConfidtion>();
        /// <summary> 说明  </summary>
        public ObservableCollection<IPropertyConfidtion> Conditions
        {
            get { return _conditions; }
            set
            {
                _conditions = value;
                RaisePropertyChanged();
            }
        }

        private ConditionOperate _conditionOperate = ConditionOperate.All;
        public ConditionOperate ConditionOperate
        {
            get { return _conditionOperate; }
            set
            {
                _conditionOperate = value;
                RaisePropertyChanged();
            }
        }


        [JsonIgnore]
        [XmlIgnore]
        public RelayCommand AddConditionCommand => new RelayCommand(l =>
        {
            PropertyInfo first = this.Properties.FirstOrDefault();
            PropertyConfidtion confidtion = new PropertyConfidtion(first);
            confidtion.Filter.IsSelected = true;
            this.Conditions.Add(confidtion);
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

        public bool IsMatch(object obj)
        {
            if (this.ConditionOperate == ConditionOperate.All)
                return this.Conditions.All(x => x.IsMatch(obj));
            if (this.ConditionOperate == ConditionOperate.Any)
                return this.Conditions.Any(x => x.IsMatch(obj));
            if (this.ConditionOperate == ConditionOperate.AnyNot)
                return this.Conditions.Any(x => !x.IsMatch(obj));
            return !this.Conditions.All(x => x.IsMatch(obj));
        }

        [JsonIgnore]
        [XmlIgnore]
        public IMetaSettingService MetaSettingService => new XmlMetaSettingService();

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
            PropertyConfidtionPrensenter find = this.MetaSettingService?.Deserilize<PropertyConfidtionPrensenter>(this.ID);
            if (find == null)
                return;

            foreach (IPropertyConfidtion item in find.Conditions)
            {
                //var propertyInfo = this.Properties.FirstOrDefault(x => x.Name == item.Filter.Name);
                PropertyConfidtion pc = new PropertyConfidtion();
                //item.Filter.PropertyInfo = propertyInfo;
                pc.Filter = item.Filter;
                this.Conditions.Add(pc);
            }
            this.ConditionOperate = find.ConditionOperate;
            _isLoaded = true;
        }
    }
}
