﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;
using System.Threading.Tasks;

namespace H.Providers.Ioc
{
    public interface INoticeMessageService
    {
        Task<bool?> ShowDialog(string message);
        void ShowError(string message);
        void ShowFatal(string message);
        void ShowInfo(string message);
        void Show(INoticeItem message);
        Task<T> ShowProgress<T>(Func<IPercentNoticeItem, T> action);
        Task<T> ShowString<T>(Func<INoticeItem, T> action);
        void ShowSuccess(string message);
        void ShowWarn(string message);
    }
}
