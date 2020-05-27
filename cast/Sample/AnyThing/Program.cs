using Castle.DynamicProxy;
using Common.CusAttribute;
using Common.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnyThing
{

    [Customer]
    public class Program
    {

        public static T GetDefault<T>() => default(T);

        [return: Customer, Description]
        static void Main(string[] args)
        {

            { // 反射生成代理

                // 使用 Castle.Core 生成代理

                ProxyGenerator proxyGenerator = new ProxyGenerator();
                Worker worker = proxyGenerator.CreateClassProxy<Worker>(new WorkerInterceptor());
                worker.Run();

            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        public class WorkerInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                Console.WriteLine("进入方法" );
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
}
