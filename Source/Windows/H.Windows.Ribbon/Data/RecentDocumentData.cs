﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace H.Windows.Ribbon
{
    public class RecentDocumentData : ToggleButtonData
    {
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                if (_index != value)
                {
                    _index = value;
                    RaisePropertyChanged();
                }
            }
        }
        private int _index;
    }
}
