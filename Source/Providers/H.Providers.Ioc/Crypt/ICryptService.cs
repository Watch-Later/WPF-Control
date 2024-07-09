﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace H.Services.Common
{
    public interface ICryptService
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}