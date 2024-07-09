﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Windows.Shell;

namespace H.Services.Common
{
    public interface ITaskBarMessage
    {
        void Show(Action<TaskbarItemInfo> action);
        void ShowImage(ImageSource image);
        void ShowNormal(Action<TaskbarItemInfo> action);
        Task ShowPercent(Action<TaskbarItemInfo> action);
        Task<bool> ShowWaitting(Func<bool> action);
    }
}
