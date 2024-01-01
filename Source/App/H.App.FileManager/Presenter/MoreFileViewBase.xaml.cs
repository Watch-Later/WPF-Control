﻿using H.Controls.TagBox;
using H.Providers.Ioc;
using H.Providers.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace H.App.FileManager
{
    public abstract class MoreFileViewBase : ModelViewModel<fm_dd_file>
    {
        protected MoreFileViewBase(fm_dd_file t) : base(t)
        {
            this.More = this.CreateMore().ToObservable();
            this.SelectedItem = this.More?.FirstOrDefault();
        }

        private ObservableCollection<IFileView> _more = new ObservableCollection<IFileView>();
        public ObservableCollection<IFileView> More
        {
            get { return _more; }
            set
            {
                _more = value;
                RaisePropertyChanged();
            }
        }

        private IFileView _selectedItem;
        public IFileView SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }


        public RelayCommand SelectionChangedCommand => new RelayCommand((s, e) =>
        {
            if (e is fm_dd_file file)
            {
                file.Watched = true;
                file.LastPlayTime = DateTime.Now;
                file.PlayCount = file.PlayCount + 1;
            }
        });

        public RelayCommand MouseDoubleClickCommand => new RelayCommand(async (s, e) =>
        {
            if (e is fm_dd_file file)
            {
                var view = Ioc.GetService<IFileToViewService>().ToView(file);
                await IocMessage.Dialog.Show(view, x => x.DialogButton = DialogButton.None);
            }
        });

        protected virtual IEnumerable<IFileView> CreateMore()
        {
            List<IFileView> mores = new List<IFileView>();
            IEnumerable<fm_dd_file> files = FileRepositoryViewModel.Instance.Collection.Select(x => x.Model);

            var t = this.Model;
            var filtToView = Ioc.GetService<IFileToViewService>();
            mores.Add(filtToView.ToView(this.Model));
            {
                IEnumerable<fm_dd_file> finds = files.Where(x => t.FavoritePath != null && x.FavoritePath != null && (x.FavoritePath?.StartsWith(t.FavoritePath) == true || t.FavoritePath?.StartsWith(x.FavoritePath) == true));
                mores.AddRange(finds.Select(l => filtToView.ToView(l, "同收藏夹")));
            }


            {
                IEnumerable<fm_dd_file> finds = files.Where(x =>
                {
                    IEnumerable<ITag> ctags = IocTagService.Instance.ToTags(t.Tags);
                    IEnumerable<ITag> xtags = IocTagService.Instance.ToTags(x.Tags);
                    IEnumerable<ITag> jtags = ctags.Join(xtags, l => l.Name, l => l.Name, (l, k) => l);
                    if (jtags.Count() > 0)
                        return true;

                    return false;
                });
                mores.AddRange(finds.Select(l => filtToView.ToView(l, "同标签")));
            }

            {
                IEnumerable<fm_dd_file> finds = files.Where(x => Path.GetDirectoryName(x.Url) == Path.GetDirectoryName(t.Url) && x.Url != t.Url);
                mores.AddRange(finds.Select(l => filtToView.ToView(l, "同文件夹")));
            }


            {
                int playCount = files.Max(x => x.PlayCount);
                IEnumerable<fm_dd_image> finds = files.OfType<fm_dd_image>().Where(x => x.PlayCount == playCount);
                mores.AddRange(finds.Select(l => filtToView.ToView(l, "播放最多")).Take(5));
            }

            {
                int score = files.Max(x => x.Score);
                IEnumerable<fm_dd_file> finds = files.Where(x => x.Score == score);
                mores.AddRange(finds.Select(l => filtToView.ToView(l, "评分最高")).Take(5));
            }

            return mores;
        }
    }
}
