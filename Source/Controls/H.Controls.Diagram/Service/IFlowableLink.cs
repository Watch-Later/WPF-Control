﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System.Threading.Tasks;

namespace H.Controls.Diagram
{
    public interface IFlowableLink : IFlowable
    {
        IFlowableResult Invoke(Part previors, Link current);
        Task<IFlowableResult> InvokeAsync(Part previors, Link current);
        Task<IFlowableResult> TryInvokeAsync(Part previors, Link current);
        bool IsMatchResult(FlowableResult flowableResult);
    }
}
