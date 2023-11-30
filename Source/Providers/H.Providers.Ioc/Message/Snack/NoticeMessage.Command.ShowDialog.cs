﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace H.Providers.Ioc
{
    public class ShowDialogSnackMessageCommand : ShowSnackMessageCommandBase
    {
        public override async void Execute(object parameter)
        {
            var r = await Ioc<ISnackMessageService>.Instance.ShowDialog(this.Message);
            if (r == true)
                Ioc<ISnackMessageService>.Instance.ShowSuccess(this.Message);
            else
                Ioc<ISnackMessageService>.Instance.ShowError(this.Message);
        }
    }
}
