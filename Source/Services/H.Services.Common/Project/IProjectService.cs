﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace H.Services.Common
{
    public interface IProjectService : ISplashSave, ISplashLoad
    {
        IProjectItem Current { get; set; }
        IProjectItem Create();
        void Add(IProjectItem project);
        void Delete(Func<IProjectItem, bool> func);
        IEnumerable<IProjectItem> Where(Func<IProjectItem, bool> func = null);
        Action<IProjectItem, IProjectItem> CurrentChanged { get; set; }
    }
}