﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

namespace H.Controls.Diagram
{
    public interface IDropable
    {
        /// <summary>
        /// 检查当前节点是否可以放下
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool CanDrop(Part part, out string message);
    }
}
