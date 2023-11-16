﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase




using H.Controls.Adorner;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace H.Controls.Diagram
{
    public class NoteResizeAdorner : ResizeAdorner
    {
        public new static ComponentResourceKey TemplateDefaultKey => new ComponentResourceKey(typeof(NoteResizeAdorner), "S.NoteResizeAdorner.Template.Default");

        public NoteResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {

        }

        protected override ControlTemplate CreateDefaultTemplate()
        {
            return Application.Current.FindResource(NoteResizeAdorner.TemplateDefaultKey) as ControlTemplate;
        }

        protected override void SetLeft(double change)
        {
            //Canvas.SetLeft(this.AdornedElement, Math.Max(Canvas.GetLeft(this.AdornedElement) + change, 0));

            var node = this.AdornedElement.GetParent<Node>();
            var point = NodeLayer.GetPosition(node);
            Point to = new Point(point.X + change, point.Y);
            NodeLayer.SetPosition(node, to);
        }
        protected override void SetTop(double change)
        {
            //Canvas.SetTop(this.AdornedElement, Math.Max(Canvas.GetTop(this.AdornedElement) + change, 0));


            var node = this.AdornedElement.GetParent<Node>();
            var point = NodeLayer.GetPosition(node);
            Point to = new Point(point.X, point.Y + change);
            NodeLayer.SetPosition(node, to);
        }

        protected override void DragMoveHorizontal(double change)
        {
            //Canvas canvas = this.AdornedElement.GetParent<Canvas>();
            //if (canvas == null) return;

            //if (Canvas.GetLeft(this.AdornedElement) + change < 0)
            //{
            //    Canvas.SetLeft(this.AdornedElement, 0);
            //    return;
            //}
            //if (Canvas.GetLeft(this.AdornedElement) + this.AdornedElement.RenderSize.Width + change > canvas.RenderSize.Width)
            //{
            //    Canvas.SetLeft(this.AdornedElement, canvas.RenderSize.Width - this.AdornedElement.RenderSize.Width);
            //    return;
            //}

            //Canvas.SetLeft(this.AdornedElement, Canvas.GetLeft(this.AdornedElement) + change);
        }
        protected override void DragMoveVertical(double change)
        {
            //Canvas canvas = this.AdornedElement.GetParent<Canvas>();

            //if (canvas == null) return;
            //if (Canvas.GetTop(this.AdornedElement) + change < 0)
            //{
            //    Canvas.SetTop(this.AdornedElement, 0);
            //    return;
            //}
            //if (Canvas.GetTop(this.AdornedElement) + this.AdornedElement.RenderSize.Height + change > canvas.RenderSize.Height)
            //{
            //    Canvas.SetTop(this.AdornedElement, canvas.RenderSize.Height - this.AdornedElement.RenderSize.Height);
            //    return;
            //}

            //Canvas.SetTop(this.AdornedElement, Canvas.GetTop(this.AdornedElement) + change);
        }


        protected override void SetHeight(double change)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;
            element.Height = Math.Max(MinValue, element.Height + change);


            var node = this.AdornedElement.GetParent<Node>();
            var point = NodeLayer.GetPosition(node);
            Point to = new Point(point.X, point.Y + (change / 2));
            NodeLayer.SetPosition(node, to);
        }
        protected override void SetWidth(double change)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;
            element.Width = Math.Max(MinValue, element.Width + change);

            var node = this.AdornedElement.GetParent<Node>();
            var point = NodeLayer.GetPosition(node);
            Point to = new Point(point.X + (change / 2), point.Y);
            NodeLayer.SetPosition(node, to);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);
            return this.AdornedElement.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            base.ArrangeOverride(finalSize);
            this._contentControl.Arrange(new Rect(new Point(0, 0), this.AdornedElement.DesiredSize));
            return finalSize;
        }
    }
}
