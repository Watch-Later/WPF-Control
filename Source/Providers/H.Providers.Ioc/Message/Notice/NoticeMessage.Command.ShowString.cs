﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Threading;

namespace H.Providers.Ioc
{
    public class ShowStringNoticeMessageCommand : ShowNoticeMessageCommandBase
    {
        public override void Execute(object parameter)
        {
            Func<INoticeItem, bool> action = x =>
            {
                for (int i = 0; i < 100; i++)
                {
                    x.Message = $"{i}/100";
                    Thread.Sleep(20);
                }
                x.Message = $"100/100";
                Thread.Sleep(1000);
                return true;
            };
            Ioc<INoticeMessageService>.Instance.ShowString(action);
        }
    }
}
