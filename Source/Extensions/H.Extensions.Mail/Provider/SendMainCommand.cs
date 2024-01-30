﻿using H.Providers.Mvvm;
using System;

namespace H.Extensions.Mail
{
    public class SendMainCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is MailMessageItem messageItem)
                Ioc<IMailService>.Instance?.Send(messageItem, SmtpSendOptions.Instance.IsBodyHtml, out string message);
        }

        public override bool CanExecute(object parameter)
        {
            return Ioc<IMailService>.Instance != null;
        }
    }

}
