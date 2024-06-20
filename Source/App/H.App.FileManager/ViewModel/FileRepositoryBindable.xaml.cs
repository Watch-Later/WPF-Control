﻿using H.Controls.TagBox;
using H.Extensions.Common;
using H.Extensions.FFMpeg;
using H.Extensions.ViewModel;
using H.Providers.Ioc;
using H.Providers.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;
using System.Xml.Serialization;

namespace H.App.FileManager
{
    public class FileRepositoryBindable : RepositoryBindable<fm_dd_file>
    {
        public FileRepositoryBindable()
        {
            this.UseMessage = false;
            this.UseOperationLog = false;
            this.Collection.PageCount = 100;

            this.UpdateCommands = this.Commands.OfType<IRelayCommand>().Where(x => x.GroupName == "更新").ToObservable();
            this.MenuCommands = this.Commands.OfType<IRelayCommand>().Where(x => x.GroupName == "菜单").ToObservable();
            this.MoreCommands = this.Commands.OfType<IRelayCommand>().Where(x => x.GroupName != "菜单" && x.GroupName != "更新").ToObservable();
        }

        public static FileRepositoryBindable Instance => DbIoc.GetService<IRepositoryBindable<fm_dd_file>>() as FileRepositoryBindable;

        public override void RefreshData(params string[] includes)
        {
            includes = includes ?? GetIncludes()?.ToArray();
            IEnumerable<SelectBindable<fm_dd_file>> collection = includes == null ? this.Repository.GetList().Select(x => new SelectBindable<fm_dd_file>(x))
            : this.Repository.GetList(includes).Select(x => new SelectBindable<fm_dd_file>(x));
            this.Collection.Load(collection);
        }

        private ObservableCollection<fm_dd_file> _hisotry = new ObservableCollection<fm_dd_file>();
        public ObservableCollection<fm_dd_file> History
        {
            get { return _hisotry; }
            set
            {
                _hisotry = value;
                RaisePropertyChanged("History");
            }
        }


        [Browsable(false)]
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<IRelayCommand> UpdateCommands { get; } = new ObservableCollection<IRelayCommand>();

        [Browsable(false)]
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<IRelayCommand> MoreCommands { get; private set; } = new ObservableCollection<IRelayCommand>();

        [Browsable(false)]
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<IRelayCommand> MenuCommands { get; private set; } = new ObservableCollection<IRelayCommand>();

        [Display(Name = "重新加载文件", GroupName = "更新")]
        public RelayCommand RefreshCommand => new RelayCommand(async (s, e) =>
        {
            if (IocProject.Instance.Current is FileProjectItem projectItem)
            {
                int r = await await IocMessage.Dialog.ShowString(async (c, x) =>
                   {
                       x.Value = "正在加载数据...";
                       List<string> files = projectItem.BaseFolder.ToDirectoryEx().GetAllFiles();
                       //Repository.Clear();

                       List<fm_dd_file> dbFiles = new List<fm_dd_file>();
                       foreach (string file in files)
                       {
                           if (c.IsCancel)
                               return -1;
                           fm_dd_file fileEnity = Ioc.GetService<IFileToEntityService>().ToEntity(file);
                           if (this.Collection.FirstOrDefault(k => k.Model.Url == file) == null)
                               dbFiles.Add(fileEnity);
                           x.Value = file;
                       }
                       await Add(dbFiles.ToArray());
                       x.Value = "加载完成，正在保存...";
                       return await Save();
                   });
                if (r >= 0)
                    IocMessage.Snack.ShowInfo("保存完成");
                else
                    IocMessage.Snack.ShowError("保存失败");
            }
        }, (s, e) => IocProject.Instance.Current is FileProjectItem);

        [Display(Name = "打开文件夹", GroupName = "菜单")]
        public RelayCommand OpenDirectoryCommand => new RelayCommand(l =>
        {
            string folder = Path.GetDirectoryName(this.Collection.SelectedItem.Model.Url);
            Process.Start(new ProcessStartInfo(folder) { UseShellExecute = true });
        }, x => this.Collection.SelectedItem != null);

        [Display(Name = "打开文件", GroupName = "菜单")]
        public RelayCommand OpenCommand => new RelayCommand(l =>
        {
            if (File.Exists(this.Collection.SelectedItem.Model.Url))
                Process.Start(new ProcessStartInfo(this.Collection.SelectedItem.Model.Url) { UseShellExecute = true });
        }, x => this.Collection.SelectedItem != null);


        [Display(Name = "复制", GroupName = "菜单")]
        public RelayCommand CopyCommand { get; set; } = new RelayCommand(l =>
        {

        });

        [Display(Name = "另存为", GroupName = "菜单")]
        public RelayCommand SaveAsCommand => new RelayCommand(l =>
        {


        });

        [Display(Name = "更新视频信息[时长、清晰度、比特率、编码格式]", GroupName = "更新")]
        public RelayCommand UpdateVieoInfoCommand => new RelayCommand(async l =>
        {
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>(), item =>
            {
                var mediaInfo = IocFFMpeg.Instance.GetMediaAnalysis(item.Url);
                if (mediaInfo == null)
                    return Tuple.Create(false, item.Name);
                item.Duration = mediaInfo.Duration.Ticks;
                var video = mediaInfo.VideoStreams?.FirstOrDefault();
                if (video == null)
                    return Tuple.Create(false, item.Name);
                item.PixelFormat = video.PixelFormat;
                item.Bitrate = video.BitRate.ToString();
                item.VideoCode = video.CodecName;
                item.PixelWidth = video.Width;
                item.PixelHeight = video.Height;
                item.Rate = video.FrameRate.ToString();
                item.Type = video.CodecLongName;
                return Tuple.Create(true, item.Name);
            });

        }, x => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>().Count() > 0);

        [Display(Name = "保存视频配置信息", GroupName = "更新")]
        public RelayCommand SaveVedioConfigCommand => new RelayCommand(async l =>
        {
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>(), item =>
            {
                string path = Path.ChangeExtension(item.Url, ".json");
                JsonSerializerService service = new JsonSerializerService();
                service.Save(path, item);
                return Tuple.Create(true, item.Name);
            });
        }, x => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>().Count() > 0);

        [Display(Name = "更新视频缩率图", GroupName = "更新")]
        public RelayCommand UpdateVedioImageCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定更新？");
            if (r != true)
                return;
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>(), item =>
            {
                string dir = Path.GetDirectoryName(item.Url);
                IEnumerable<string> images = Directory.GetFiles(dir).Where(x => x.IsImage() && Path.GetFileNameWithoutExtension(x).StartsWith(item.Name));
                Application.Current.Dispatcher.Invoke(() =>
                {
                    item.Images.Clear();
                });
                foreach (string image in images)
                {
                    var vimage = new fm_dd_video_image()
                    {
                        Url = image,
                        Name = Path.GetFileNameWithoutExtension(image)
                    };

                    var array = image.Split('_');
                    if (array.Length > 1)
                    {
                        if (long.TryParse(array[1].Split('.')[0], out long v))
                        {
                            vimage.TimeStamp = v;
                        }
                    }
                    if (array.Length > 2)
                    {
                        vimage.DisplayName = array[2];
                    }
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        item.Images.Add(vimage);
                    });
                }
                item.SelectedImageIndex = 0;
                return Tuple.Create(true, item.Name);
            });
        }, x => this.Collection.FilterSource.Select(x => x.Model).OfType<fm_dd_video>().Count() > 0);

        [Display(Name = "根据名称加载标签", GroupName = "更新")]
        public RelayCommand UpdateTagCommand => new RelayCommand(async l =>
        {
            ITagService tagService = Ioc.GetService<ITagService>();
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Select(x => x.Model), item =>
            {
                if (item is fm_dd_file)
                {
                    IEnumerable<ITag> findtags = tagService.Collection.Where(x => x.GroupName == null).Where(x => item.Url.Contains(x.Name));
                    foreach (ITag find in findtags)
                    {
                        item.Tags = tagService.ConvertToCheck(item.Tags, find);
                    }
                }
                if (item is fm_dd_image image)
                {
                    {
                        IEnumerable<ITag> findtags = tagService.Collection.Where(x => x.GroupName == "Object").Where(x => item.Url.Contains(x.Name));
                        foreach (ITag find in findtags)
                        {
                            image.Object = tagService.ConvertToCheck(image.Object, find);
                        }
                    }

                    {
                        IEnumerable<ITag> findtags = tagService.Collection.Where(x => x.GroupName == "Area").Where(x => item.Url.Contains(x.Name));
                        foreach (ITag find in findtags)
                        {
                            image.Area = tagService.ConvertToCheck(image.Area, find);
                        }
                    }

                    {
                        IEnumerable<ITag> findtags = tagService.Collection.Where(x => x.GroupName == "Articulation").Where(x => item.Url.Contains(x.Name));
                        foreach (ITag find in findtags)
                        {
                            image.Articulation = tagService.ConvertToCheck(image.Articulation, find);
                        }
                    }
                }
                return Tuple.Create(true, item.Name);
            });
        }, x => this.Collection.FilterSource.Count() > 0);

        [Display(Name = "移除不存在的文件", GroupName = "更新")]
        public RelayCommand RemoveAbsentFileCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定移除？");
            if (r != true)
                return;

            await IocMessage.Dialog.ShowWait(
                 x =>
                {
                    this.Collection.RemoveAll(x => !File.Exists(x.Model.Url));
                    return true;
                });
        }, x => this.Collection.FilterSource.Count > 0);

        [Display(Name = "彻底删除", GroupName = "菜单")]
        public RelayCommand DeleteSelectedFileCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定删除？");
            if (r != true)
                return;
            if (File.Exists(this.Collection.SelectedItem.Model.Url))
                File.Delete(this.Collection.SelectedItem.Model.Url);
            await this.Delete(this.Collection.SelectedItem);
            IocMessage.Snack.ShowInfo($"操作完成");

        }, x => this.Collection.SelectedItem != null);


        [Display(Name = "移除", GroupName = "菜单")]
        public RelayCommand RemoveSelectedFileCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定删除？");
            if (r != true)
                return;
            await this.Delete(this.Collection.SelectedItem);
            IocMessage.Snack.ShowInfo($"操作完成");

        }, x => this.Collection.SelectedItem != null);

        [Display(Name = "彻底删除当前筛选的文件", GroupName = "更新")]
        public RelayCommand DeleteFilterFilesCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定删除？");
            if (r != true)
                return;

            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource, item =>
            {
                if (File.Exists(item.Model.Url))
                    File.Delete(item.Model.Url);
                this.Repository.Delete(item.Model);
                //this.Delete(item).Wait();
                return Tuple.Create(true, item.Model.Name);
            });
            this.Collection.Remove(this.Collection.FilterSource.ToArray());
        }, x => this.Collection.FilterSource.Count > 0);

        [Display(Name = "移除当前筛选的文件", GroupName = "更新")]
        public RelayCommand RemoveFilterFilesCommand => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定移除？");
            if (r != true)
                return;

            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource, item =>
            {
                this.Repository.Delete(item.Model);
                //filtersfilters
                return Tuple.Create(true, item.Model.Name);
            });
            this.Collection.Remove(this.Collection.FilterSource.ToArray());
        }, x => this.Collection.FilterSource.Count > 0);

        [Display(Name = "移除评分低于1的文件", GroupName = "更新")]
        public RelayCommand RemoveScore1Command => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定移除？");
            if (r != true)
                return;
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Where(x => x.Model.Score < 1), item =>
            {
                this.Repository.Delete(item.Model);
                return Tuple.Create(true, item.Model.Name);
            });
            this.Collection.RemoveAll(x => x.Model.Score < 1);
        }, x => this.Collection.FilterSource.Where(x => x.Model.Score < 1).Count() > 0);

        [Display(Name = "彻底删除评分低于1的文件", GroupName = "更新")]
        public RelayCommand DeleteScore1Command => new RelayCommand(async l =>
        {
            bool? r = await IocMessage.Dialog.Show("确定删除？");
            if (r != true)
                return;
            await IocMessage.Dialog.ShowForeach(() => this.Collection.FilterSource.Where(x => x.Model.Score < 1), item =>
            {
                if (File.Exists(item.Model.Url))
                    File.Delete(item.Model.Url);
                this.Repository.Delete(item.Model);
                return Tuple.Create(true, item.Model.Name);
            });
            this.Collection.RemoveAll(x => x.Model.Score < 1);
        }, x => this.Collection.FilterSource.Where(x => x.Model.Score < 1).Count() > 0);

        [Browsable(false)]
        public RelayCommand SelectionChangedCommand => new RelayCommand((s, e) =>
        {
            if (e is fm_dd_file file)
            {
                file.Watched = true;
                file.LastPlayTime = DateTime.Now;
                file.PlayCount = file.PlayCount + 1;
                this.History.Add(file);
            }
        });

        [Browsable(false)]
        public RelayCommand MouseDoubleClickCommand => new RelayCommand(async (s, e) =>
        {
            var file = e is fm_dd_file item ? item : this.Collection.SelectedItem.Model;
            if (file != null)
            {
                this.History.Add(file);
                var view = Ioc.GetService<IFileToViewService>().ToView(file);
                await IocMessage.Dialog.Show(view, x => x.DialogButton = DialogButton.None);
            }
        });
    }
}
