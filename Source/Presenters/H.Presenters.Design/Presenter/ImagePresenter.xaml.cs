﻿
using H.Providers.Mvvm;
using H.Styles.Default;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;

namespace H.Presenters.Design
{
    [Displayer(Name = "图片", Icon = "\xe606")]
    public class ImagePresenter : CommandsDesignPresenterBase
    {
        public ImagePresenter()
        {
            ImageSource = LogoDataProvider.Logo;
            Width = 200;
            Height = 80;
        }
        private ImageSource _imageSource;
        [Display(Name = "图像资源", GroupName = "常用,数据")]
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                RaisePropertyChanged();
            }
        }

        private Stretch _stretch = Stretch.Uniform;
        [Display(Name = "拉伸方式", GroupName = "常用,布局")]
        public Stretch Stretch
        {
            get { return _stretch; }
            set
            {
                _stretch = value;
                RaisePropertyChanged();
            }
        }
    }
}
