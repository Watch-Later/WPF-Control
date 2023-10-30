﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System.Windows;
using System.Windows.Controls;

namespace H.Controls.PropertyGrid
{
    public class TextBlockEditor : TypeEditor<TextBlock>
    {
        protected override TextBlock CreateEditor()
        {
            return new PropertyGridEditorTextBlock();
        }

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = TextBlock.TextProperty;
        }

        protected override void SetControlProperties(PropertyItem propertyItem)
        {
            Editor.Margin = new System.Windows.Thickness(5, 0, 0, 0);
            Editor.TextTrimming = TextTrimming.CharacterEllipsis;
        }
    }

    public class PropertyGridEditorTextBlock : TextBlock
    {
        static PropertyGridEditorTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBlock), new FrameworkPropertyMetadata(typeof(PropertyGridEditorTextBlock)));
        }
    }
}
