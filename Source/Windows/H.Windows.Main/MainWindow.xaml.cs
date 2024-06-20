﻿using System.Windows;
using System.Windows.Controls;

namespace H.Windows.Main
{
    public interface IMainWindow
    {
        void CloseOver();
        void ShowOver();
    }

    [TemplatePart(Name = "PART_Over")]
    public class MainWindow : System.Windows.Window, IMainWindow
    {
        private Border _boderOver = null;
        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }

        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._boderOver = this.Template.FindName("PART_Over", this) as Border;
        }


        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }


        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(MainWindow), new FrameworkPropertyMetadata(45.0, (d, e) =>
            {
                MainWindow control = d as MainWindow;

                if (control == null) return;

                if (e.OldValue is double o)
                {

                }

                if (e.NewValue is double n)
                {

                }

            }));


        public ControlTemplate CaptionTempate
        {
            get { return (ControlTemplate)GetValue(CaptionTempateProperty); }
            set { SetValue(CaptionTempateProperty, value); }
        }


        public static readonly DependencyProperty CaptionTempateProperty =
            DependencyProperty.Register("CaptionTempate", typeof(ControlTemplate), typeof(MainWindow), new FrameworkPropertyMetadata(default(ControlTemplate), (d, e) =>
            {
                MainWindow control = d as MainWindow;

                if (control == null) return;

                if (e.OldValue is ControlTemplate o)
                {

                }

                if (e.NewValue is ControlTemplate n)
                {

                }

            }));



        public ControlTemplate SideTemplate
        {
            get { return (ControlTemplate)GetValue(SideTemplateProperty); }
            set { SetValue(SideTemplateProperty, value); }
        }


        public static readonly DependencyProperty SideTemplateProperty =
            DependencyProperty.Register("SideTemplate", typeof(ControlTemplate), typeof(MainWindow), new FrameworkPropertyMetadata(default(ControlTemplate), (d, e) =>
            {
                MainWindow control = d as MainWindow;

                if (control == null) return;

                if (e.OldValue is ControlTemplate o)
                {

                }

                if (e.NewValue is ControlTemplate n)
                {

                }

            }));


        public void ShowOver()
        {
            this._boderOver.Visibility = Visibility.Visible;
        }

        public void CloseOver()
        {
            this._boderOver.Visibility = Visibility.Collapsed;
        }


    }
}
