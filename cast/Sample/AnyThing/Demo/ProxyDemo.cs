using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/27/2020 3:22:36 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ProxyDemo
    {

        public void Run()
        {
            // 反射生成代理

            // 使用 Castle.Core 生成代理

            ProxyGenerator proxyGenerator = new ProxyGenerator();
            Worker worker = proxyGenerator.CreateClassProxy<Worker>(new WorkerInterceptor());
            worker.Run();


        }

    }


    public class WorkerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("进入方法");
            invocation.Proceed();
            Console.WriteLine("离开方法，返回值:" + invocation.ReturnValue);
        }
    }

    public class Worker
    {
        public void Run()
        {
            Console.WriteLine("I'm working");
        }
    }

}
