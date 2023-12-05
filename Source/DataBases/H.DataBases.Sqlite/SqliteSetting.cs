﻿


#if NETFRAMEWORK
using System.Data.Entity;
#endif

#if NETCOREAPP
#endif
using H.DataBases.Share;
using H.Providers.Ioc;
using System.ComponentModel.DataAnnotations;

namespace H.DataBases.Sqlite
{
    [Display(Name = "数据库配置", GroupName = SystemSetting.GroupApp)]
    public class SqliteSetting : SqliteSettingBase<SqliteSetting>, ISqliteOption, IDbSetting
    {

    }
}
