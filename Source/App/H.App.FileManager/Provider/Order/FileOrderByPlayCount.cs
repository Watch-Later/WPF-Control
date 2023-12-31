﻿
using H.Controls.OrderBox;
using H.Providers.Mvvm;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace H.App.FileManager
{
    [Display(Name = "按打开次数")]
    public class FileOrderByPlayCount : OrderBase
    {
        public override IEnumerable Where(IEnumerable from)
        {
            if (this.UseDesc)
                return from.OfType<IModelViewModel<fm_dd_file>>().OrderByDescending(x => x.Model.PlayCount);
            return from.OfType<IModelViewModel<fm_dd_file>>().OrderBy(x => x.Model.PlayCount);

        }
    }
}
