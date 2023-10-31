﻿using H.Presenters.Common;
using H.Providers.Ioc;
using H.Windows.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace H.Modules.Message
{
    public class DialogMessage : IDialogMessage
    {
        public async Task<bool?> Show(object presenter, Action<Control> action = null, string title = null, Func<bool> canSumit = null, bool ownerMainWindow = true)
        {
            var r = DialogWindow.ShowPresenter(presenter, action, title, canSumit, ownerMainWindow);
            return await Task.FromResult(r);
        }

        public async Task<bool?> ShowIoc(Type type, Action<Control> action = null, string title = null, Func<bool> canSumit = null, bool ownerMainWindow = true)
        {
            var r = DialogWindow.ShowIoc(type, action, title, ownerMainWindow);
            return await Task.FromResult(r);
        }

        public async Task<bool?> ShowIoc<T>(Action<Control> action = null, string title = null, Func<bool> canSumit = null, bool ownerMainWindow = true)
        {
            var r = DialogWindow.ShowIoc<T>(action, title, ownerMainWindow);
            return await Task.FromResult(r);
        }

        public async Task<bool?> ShowMessage(string message, string title = "提示", Action<Control> action = null, bool ownerMainWindow = true)
        {
            var r = DialogWindow.ShowMessage(message, title, ownerMainWindow, action);
            return await Task.FromResult(r);
        }

        public async Task<T> ShowPercent<T>(Func<IPercentPresenter, ICancelable, T> action, Action<Control> build = null, string title = null, bool ownerMainWindow = true)
        {
            var p = new PercentPresenter();
            var r = DialogWindow.ShowAction(p, cancel => action.Invoke(p, cancel), x =>
            {

            }, title, ownerMainWindow);
            return await Task.FromResult(r);
        }

        public async Task<T> ShowString<T>(Func<IStringPresenter, ICancelable, T> action, Action<Control> build = null, string title = null, bool ownerMainWindow = true)
        {
            var p = new StringPresenter();
            var r = DialogWindow.ShowAction(p, cancel => action.Invoke(p, cancel), x =>
            {
                x.HorizontalContentAlignment = HorizontalAlignment.Center;
            }, title, ownerMainWindow);
            return await Task.FromResult(r);
        }

        public async Task<T> ShowWait<T>(Func<ICancelable, T> action, Action<Control> build = null, string title = null, bool ownerMainWindow = true)
        {
            var p = new WaitPresenter();
            var r = DialogWindow.ShowAction(p, cancel => action.Invoke(cancel), x =>
            {

            }, title, ownerMainWindow);
            return await Task.FromResult(r);
        }
    }
}
