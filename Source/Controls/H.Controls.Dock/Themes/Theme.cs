﻿/************************************************************************
   H.Controls.Dock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at https://opensource.org/licenses/MS-PL
 ************************************************************************/

using System;
using System.Windows;

namespace H.Controls.Dock.Themes
{
    /// <summary>Provides a base class for the implementation of a custom H.Controls.Dock WPF theme.</summary>
    public abstract class Theme : DependencyObject
    {
        /// <summary>Class constructor</summary>
        public Theme()
        {
        }

        /// <summary>Gets the <see cref="Uri"/> of the XAML that contains the definition for this H.Controls.Dock theme.</summary>
        /// <returns><see cref="Uri"/> of the XAML that contains the definition for this custom H.Controls.Dock theme</returns>
        public abstract Uri GetResourceUri();
    }
}
