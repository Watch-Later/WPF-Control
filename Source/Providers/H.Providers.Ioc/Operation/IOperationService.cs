﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;
using System.Runtime.CompilerServices;

namespace H.Providers.Ioc
{
    public interface IOperationService
    {
        void Log<T>(string title, string message = null, OperationType operationType = OperationType.Default, bool result = true, [CallerMemberName] string methodName = null);
    }
}