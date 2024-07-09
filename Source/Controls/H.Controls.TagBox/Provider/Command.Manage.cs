﻿using H.Services.Common;
using H.Mvvm;
using System;
using System.Linq;

namespace H.Controls.TagBox
{
    public class ManageTagCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            var ioc = Ioc.GetService<ITagService>();
            var tag = new TagsPresenter();
            tag.GroupName = parameter?.ToString();
            var temp = ioc.Collection.Where(x => x.GroupName == parameter?.ToString()).ToList();
            tag.Collection = temp.ToObservable();
            var r = await IocMessage.Dialog.Show(tag);
            if (r != true)
                return;
            foreach (var item in temp)
            {
                if (tag.Collection.Contains(item))
                    continue;
                ioc.Delete(item);
            }
            foreach (var item in tag.Collection)
            {
                if (temp.Contains(item))
                    continue;
                ioc.Add(item);
            }
            ioc.Save(out string message);
        }

        public override bool CanExecute(object parameter)
        {
            return Ioc.Exist<ITagService>();
        }
    }
}
