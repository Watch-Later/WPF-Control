﻿using H.Providers.Mvvm;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Windows.Media;

namespace H.Controls.TagBox
{
    public class Tag : NotifyPropertyChangedBase, ITag
    {
        private string _name;
        [Required]
        [Display(Name = "名称")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private Brush _background;
        [JsonConverter(typeof(TypeJsonConverter<Brush>))]
        [Display(Name = "颜色")]
        public Brush Background
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged();
            }
        }

        private string _description;
        [Display(Name = "说明")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }

        private string _groupName;
        [Browsable(false)]
        [Display(Name = "分组")]
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                RaisePropertyChanged();
            }
        }

        public override string ToString() => this.Name;
    }
}
