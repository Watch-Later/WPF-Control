﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace H.Providers.Ioc
{
    public interface IRegisterService
    {
        bool Register(string mail,string account, string password, out string message);
        bool ResetPassword(string mail, string account, string password, out string message);
    }
}