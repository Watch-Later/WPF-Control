﻿using H.Controls.Form;
using H.Providers.Ioc;
using H.Windows.Dialog;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace H.Modules.Message
{
    public class FormMessage : IFormMessage
    {
        public async Task<bool?> ShowEdit<T>(T value, Predicate<T> match = null, Action<Control> action = null, string title = null, bool ownerMainWindow = true)
        {
            Func<bool> canSumit = () =>
            {
                if (value.ModelStateDeep(out string error) == false)
                {
                    IocMessage.Dialog.ShowMessage(error);
                    return false;
                }
                return match?.Invoke(value) != false;
            };
            var presenter = new FormPresenter(value);
            var r = DialogWindow.ShowPresenter(presenter, action, DialogButton.Sumit, title, canSumit, ownerMainWindow);
            return await Task.FromResult(r);
        }
        public async Task<bool?> ShowView<T>(T value, Predicate<T> match = null, Action<Control> action = null, string title = null, bool ownerMainWindow = true)
        {
            Func<bool> canSumit = () =>
            {
                return match?.Invoke(value) != false;
            };
            var presenter = new FormPresenter(value);
            presenter.UsePropertyView = true;
            var r = DialogWindow.ShowPresenter(presenter, action, DialogButton.Sumit, title, canSumit, ownerMainWindow);
            return await Task.FromResult(r);
        }
    }
}
