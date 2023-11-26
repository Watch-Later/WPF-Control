﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;
using System.Windows;

namespace H.Providers.Ioc
{
    public static class IocMessage
    {
        public static IWindowMessage Window => System.Ioc.GetService<IWindowMessage>(throwIfNone: false);
        public static IDialogMessageService Dialog => System.Ioc.GetService<IDialogMessageService>(throwIfNone: false);
        public static ISnackMessageService Snack => System.Ioc.GetService<ISnackMessageService>(throwIfNone: false);
        public static ITaskBarMessage TaskBar => System.Ioc.GetService<ITaskBarMessage>(throwIfNone: false);
        public static ISystemNotifyMessage SystemNotify => System.Ioc.GetService<ISystemNotifyMessage>(throwIfNone: false);
        public static INoticeMessageService Notify => System.Ioc.GetService<INoticeMessageService>(throwIfNone: false);
        public static IFormMessageService Form => System.Ioc.GetService<IFormMessageService>(throwIfNone: false);

        //public static void ShowMessage(string message, string title = "提示")
        //{
        //    if (Dialog == null)
        //    {
        //        MessageBox.Show(message, title);
        //        return;
        //    }
        //    else
        //    {
        //        Dialog.ShowMessage(message, title);
        //    }
        //}

        public static bool? ShowDialogMessage(string message, string title = "提示", DialogButton dialogButton = DialogButton.Sumit)
        {
            if (Dialog == null)
            {
                MessageBoxButton boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.Sumit)
                    boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.Cancel)
                    boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.SumitAndCancel)
                    boxButton = MessageBoxButton.OKCancel;
                MessageBoxResult r = MessageBox.Show(message, title, boxButton);
                if (r == MessageBoxResult.None)
                    return new Nullable<bool>();
                return new Nullable<bool>(r == MessageBoxResult.OK);
            }
            else
            {
                return Dialog.ShowMessage(message, title, dialogButton).Result;
            }
        }

        public static bool? ShowWindowgMessage(string message, string title = "提示", DialogButton dialogButton = DialogButton.Sumit)
        {
            if (Window == null)
            {
                MessageBoxButton boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.Sumit)
                    boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.Cancel)
                    boxButton = MessageBoxButton.OK;
                if (dialogButton == DialogButton.SumitAndCancel)
                    boxButton = MessageBoxButton.OKCancel;
                MessageBoxResult r = MessageBox.Show(message, title, boxButton);
                if (r == MessageBoxResult.None)
                    return new Nullable<bool>();
                return new Nullable<bool>(r == MessageBoxResult.OK);
            }
            else
            {
                return Window.ShowMessage(message, title, dialogButton).Result;
            }
        }


        public static void ShowSnackMessage(string message)
        {
            if (Snack == null)
            {

            }
            else
            {
                Snack.ShowInfo(message);
            }
        }
    }
}
