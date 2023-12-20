﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace H.Controls.TagBox
{
    [Display(Name = "标签管理")]
    public class TagService : ITagService
    {
        public IEnumerable<ITag> Collection => TagOptions.Instance.Tags;

        public void Add(params ITag[] ts)
        {
            TagOptions.Instance.Tags.AddRange(ts.OfType<Tag>());
        }

        public ITag Create()
        {
            return new Tag();
        }

        public void Delete(params ITag[] ts)
        {
            var tags = ts.OfType<Tag>();
            foreach (var t in tags)
            {
                TagOptions.Instance.Tags.Remove(t);
            }
        }

        public void Load()
        {
            TagOptions.Instance.Load();
        }

        public bool Save(out string message)
        {
            return TagOptions.Instance.Save(out message);
        }
    }
}
