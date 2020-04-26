using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/23/2020 5:02:47 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ThreadDemo
    {

        void Run()/// requried: 先输出1再输出2
        {
            Work(() => { Console.WriteLine("2"); });
            //Work();
            //Work().Wait();
            //Thread.Sleep(10);
            //Console.WriteLine("2");
        }


        public void Work(Action action)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(1);
                action();
            }));

            t.Start();
        }

        //public Task Work()
        //{

        //    return Task.Run(() =>
        //    {
        //        Console.WriteLine(1);
        //    });

        //}

        public void Work()
        {

            // 效率低
            Task empty = new Task(() => { });

            /// 工作场景-->grpc
            /// 高性能通信的基础
            Thread t = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(1);
                empty.Start();
            }));

            t.Start();
            empty.Wait();

        }

    }
}
