﻿using H.Extensions.TypeConverter;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace H.Presenters.Design
{
    [Display(Name = "DefinitionGrid")]
    public class DefinitionGridPresenter : GridPresenterBase
    {
        private ObservableCollection<GridLength> _rows;
        [Display(Name = "行数", GroupName = "常用,样式")]
        [TypeConverter(typeof(ObservableCollectionTypeConverter<GridLength, GridLengthConverter>))]
        public ObservableCollection<GridLength> Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<GridLength> _columns;
        [Display(Name = "列数", GroupName = "常用,样式")]
        [TypeConverter(typeof(ObservableCollectionTypeConverter<GridLength, GridLengthConverter>))]
        public ObservableCollection<GridLength> Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;
                RaisePropertyChanged();
            }
        }
    }
}
