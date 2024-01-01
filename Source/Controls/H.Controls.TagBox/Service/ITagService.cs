﻿using H.Providers.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H.Controls.TagBox
{
    public interface ITagService : IDataSource<ITag>, ISplashLoad, ISplashSave
    {
        ITag Create();
        string ConvertToCheck(string value, ITag tag);
        string ConvertToUnCheck(string value, ITag tag);
        bool ContainTag(string name, ITag tag);
        IEnumerable<ITag> ToTags(string name);
    }

    public class IocTagService : Ioc<ITagService>
    {

    }
}
