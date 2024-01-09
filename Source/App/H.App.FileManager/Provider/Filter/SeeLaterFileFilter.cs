﻿using H.Controls.FilterBox;
using H.Providers.Mvvm;

namespace H.App.FileManager
{
    public class SeeLaterFileFilter : FilterBase
    {
        public bool Value { get; set; }
        public override bool IsMatch(object obj)
        {
            if (obj is ModelViewModel<fm_dd_file> file)
            {
                return file.Model.SeeLater == Value;
            }
            return false;
        }
    }
}
