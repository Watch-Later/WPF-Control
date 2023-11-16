﻿using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace H.Providers.Ioc
{
    public interface IZoombox
    {
        void FillToBounds();
        void FitToBounds();
        void Zoom(double percentage);
        void Zoom(double percentage, Point relativeTo);
        void ZoomTo(double scale);
        void ZoomTo(double scale, Point relativeTo);
        void ZoomTo(Point position);
        void ZoomTo(Rect region);
    }
}