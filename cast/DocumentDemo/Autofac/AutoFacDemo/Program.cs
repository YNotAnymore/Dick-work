using System;
using Autofac;

namespace AutoFacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<DaliyWork>();

            //builder.RegisterType<DaliyWork>().As<IJob>();

            // 当需要使用container.Resolve<DaliyWork>() 时使用 Or 使用 builder.RegisterType<DaliyWork>();
            builder.RegisterType<DaliyWork>().AsSelf().As<IJob>();

            using (var container = builder.Build())
            {
                //  容器在应用的生命周期内一直存在. 如果你直接从该容器中解析了太多东西, 应用结束时将会有一堆东西等着被释放. 这是非常不合适的 (很有可能造成"内存泄漏").

                // 即 直接使用容器解析组件时，组件的生命周期会和容器生命周期一样长，而容器会生存到程序结束才释放
                // 若是解析了大量组件时，程序结束时会需要释放大量组件，这是非常不合适的 (很有可能造成"内存泄漏").
                container.Resolve<IJob>().Work();
                container.Resolve<DaliyWork>().Work();

                // 开辟子生命周期，让在子生命周期中解析的组件随着子生命周期释放而释放
                using (var scope = container.BeginLifetimeScope())
                {
                    scope.Resolve<IJob>().Work();
                    scope.Resolve<DaliyWork>().Work();
                }

                Console.WriteLine("container dispose");

            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }
    }

    interface IJob
    {
        void Work();
    }

    public class DaliyWork : IJob, IDisposable
    {
        public DaliyWork()
        {
        }

        public void Work()
        {
            Console.WriteLine("play computer");
        }

        public void Dispose()
        {
            Console.WriteLine($"{nameof(DaliyWork)} 被释放了。");
        }
    }
}