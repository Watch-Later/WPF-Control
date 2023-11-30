﻿using H.Extensions.Setting;
using H.Providers.Ioc;
using H.Providers.Mvvm;



#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
using Microsoft.Extensions.DependencyInjection;
using System;
#endif
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace H.DataBases.Share
{
    public abstract class DbSettingBase<T> : LazySettingInstance<T>, IDbSetting where T : new()
    {
        public abstract string GetConnect();

        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [Display(Name = "测试连接")]
        public RelayCommand ConnectCommand => new RelayCommand(async (s, e) =>
        {
            Tuple<bool, string> r = await Task.Run(() =>
              {
                  s.IsBusy = true;
                  s.Message = "正在连接...";

                  System.Collections.Generic.IEnumerable<IDbConnectService> inits = Ioc.Services.GetServices<ISplashLoad>().OfType<IDbConnectService>();
                  bool r = false;
                  foreach (IDbConnectService init in inits)
                  {
                      r = init.TryConnect(out string message);
                      if (r == false)
                      {
                          s.Message = message;
                          break;
                      }
                  }

                  Thread.Sleep(500);
                  s.IsBusy = false;
                  CommandManager.InvalidateRequerySuggested();
                  return Tuple.Create(r, s.Message);
              });

            if (r.Item1 == false)
                await IocMessage.Window.ShowMessage(r.Item2, "连接失败");
        });

        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [Display(Name = "保存配置")]
        public RelayCommand SaveCommand => new RelayCommand((s, e) =>
        {
            bool r = this.Save(out string message);
            if (r)
            {
                IocMessage.Window.ShowMessage("保存成功");
            }
            else
            {
                IocMessage.Window.ShowMessage(message, "保存失败");
            }
        });
    }

}
