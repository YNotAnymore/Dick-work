using Autofac;
using DotNetCore.CAP;
using DotNetCore.CAP.Internal;
using DotNetCore.CAP.Processor;
using DotNetCore.CAP.Serialization;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSample.Extension
{
    public static class AutofacExt
    {


        public static void TryAddSingleton<T>(this ContainerBuilder builder)
        {
            builder.RegisterType<T>().SingleInstance();
        }

        public static void TryAddSingleton<T,Impl>(this ContainerBuilder builder) where Impl:T
        {
            builder.RegisterType<T>().As<Impl>().SingleInstance();
        }

    }
}
