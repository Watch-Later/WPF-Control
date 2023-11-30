﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control



using H.Controls.Adorner;
using System;
using System.Windows;

namespace H.Modules.Guide
{
    public class GuideBoxAdorner : VisualCollectionAdornerBase
    {
        private GuideBox _guideBox;
        public GuideBoxAdorner(UIElement adornedElement, Action close) : base(adornedElement)
        {
            _guideBox = new GuideBox(adornedElement);
            _visualCollection.Add(_guideBox);
            _guideBox.Closed += (l, k) =>
            {
                close?.Invoke();
            };
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this._guideBox.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            return new Size(Math.Max(this._guideBox.DesiredSize.Width, this.AdornedElement.DesiredSize.Width), Math.Max(this._guideBox.DesiredSize.Height, this.AdornedElement.DesiredSize.Height));
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this._guideBox.Arrange(new Rect(this.AdornedElement.RenderSize));
            return base.ArrangeOverride(finalSize);
        }
    }
}
