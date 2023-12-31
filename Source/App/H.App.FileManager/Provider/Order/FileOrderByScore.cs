﻿
using H.Controls.OrderBox;
using H.Providers.Mvvm;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace H.App.FileManager
{
    [Display(Name = "按评分")]
    public class FileOrderByScore : OrderBase
    {
        public override IEnumerable Where(IEnumerable from)
        {
            if (this.UseDesc)
                return from.OfType<IModelViewModel<fm_dd_file>>().OrderByDescending(x => x.Model.Score);
            return from.OfType<IModelViewModel<fm_dd_file>>().OrderBy(x => x.Model.Score);
        }
    }
}
