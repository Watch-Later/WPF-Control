﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;

namespace H.Controls.PropertyGrid
{
    public class InvalidTemplateException : Exception
    {
        #region Constructors

        public InvalidTemplateException(string message)
          : base(message)
        {
        }

        public InvalidTemplateException(string message, Exception innerException)
          : base(message, innerException)
        {
        }

        #endregion
    }
}
