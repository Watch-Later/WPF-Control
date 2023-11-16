﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace System
{
    public static class Ioc
    {
        private static IServiceProvider _services = null;
        public static IServiceProvider Services => _services;
        public static void Build(IServiceProvider services)
        {
            _services = services;
        }

        public static T GetService<T>(bool throwIfNone = true)
        {
            if (_services == null)
            {
                if (throwIfNone)
                    throw new ArgumentNullException($"请先注册使用ApplicationBase注册<IServiceCollection>接口");
                else
                    return default(T);
            }
            var r = (T)_services.GetService(typeof(T));
            if (r == null && throwIfNone)
            {
                System.Diagnostics.Debug.WriteLine(typeof(T));
                throw new ArgumentNullException($"请先注册<{typeof(T)}>接口");
            }
            return r;
        }

        public static T GetService<T>(Type type, bool throwIfNone = true)
        {
            var r = (T)_services.GetService(type);
            if (r == null && throwIfNone)
            {
                System.Diagnostics.Debug.WriteLine(type);
                throw new ArgumentNullException($"请先注册<{type}>接口");
            }
            return r;
        }

        public static bool Exist<T>()
        {
            return GetService<T>(throwIfNone: false) != null;
        }
    }

    public abstract class Ioc<T, Interface> where T : class, Interface, new()
    {
        public static T Instance => Ioc.GetService<Interface>() as T;
    }

    public abstract class IocThrowIfNone<Interface>
    {
        public static Interface Instance => Ioc.GetService<Interface>();
    }

    public abstract class Ioc<Interface>
    {
        public static Interface Instance
        {
            get
            {
                var r = Ioc.Services?.GetService(typeof(Interface));
                return r == null ? default : (Interface)r;
            }
        }
    }
}
