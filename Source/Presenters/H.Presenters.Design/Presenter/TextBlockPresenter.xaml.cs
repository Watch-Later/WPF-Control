﻿
using H.Providers.Mvvm;
using H.Themes.Default;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Media;

namespace H.Presenters.Design
{
    [Display(Name = "文本")]
    public class TextBlockPresenter : CommandsDesignPresenterBase, ITextData
    {
        public TextBlockPresenter()
        {
            Text = Name;
        }
        public override void LoadDefault()
        {
            base.LoadDefault();
            FontSize = (double)Application.Current.FindResource(FontSizeKeys.Default);
            //this.FontFamily = Application.Current.FindResource(SystemKeys.FontFamily) as FontFamily;
            FontStyle = FontStyles.Normal;
            FontWeight = FontWeights.Normal;
            FontStretch = FontStretches.Normal;
            //this.Foreground = Application.Current.FindResource(BrushKeys.Foreground) as Brush;
            //this.Height = (double)Application.Current.FindResource(SystemKeys.ItemHeight);
            Foreground = Brushes.Black;
            Height = (double)Application.Current.FindResource(LayoutKeys.RowHeight);
            VerticalContentAlignment = VerticalAlignment.Center;
        }
        private string _text;
        [Display(Name = "文本", GroupName = "常用,数据")]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }

        private double _fontSize;
        [Display(Name = "字号", GroupName = "常用,样式")]
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                RaisePropertyChanged();
            }
        }

        private FontFamily _fontFamily;
        [Display(Name = "字体", GroupName = "样式")]
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                _fontFamily = value;
                RaisePropertyChanged();
            }
        }


        private FontStyle _fontStyle;
        [Display(Name = "字体样式", GroupName = "样式")]
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set
            {
                _fontStyle = value;
                RaisePropertyChanged();
            }
        }

        private FontWeight _fontWeight;
        [Display(Name = "字体加粗", GroupName = "样式")]
        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set
            {
                _fontWeight = value;
                RaisePropertyChanged();
            }
        }

        private FontStretch _fontStretch;
        [Display(Name = "字体展开", GroupName = "样式")]
        public FontStretch FontStretch
        {
            get { return _fontStretch; }
            set
            {
                _fontStretch = value;
                RaisePropertyChanged();
            }
        }

        private Brush _foreground;
        [DefaultValue(null)]
        [Display(Name = "文本颜色", GroupName = "常用,样式")]
        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                RaisePropertyChanged();
            }
        }
    }
}
