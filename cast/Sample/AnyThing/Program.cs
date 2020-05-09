using AnyThing.Demo;
using Common.CusAttribute;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing
{

    [Customer]
    class Program
    {

        [return: Customer, Description]
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        private static void TestChannelDemo()
        {
            CancellationToken token = new CancellationToken();

            //// TA别读太快了，弄1个task读
            //ChannelDemo channelDemo = new ChannelDemo(1, token);

            // 发得有点快，你多弄几个收吧
            ChannelDemo channelDemo = new ChannelDemo(10, token);

            //// 单线程发100次
            //for (int i = 0; i < 100; i++)
            //{
            //    channelDemo.Write($"这是第{(i + 1)}条消息");
            //}

            //// 等待0.5s后发送
            //Thread.Sleep(500);

            // 并发发送
            Parallel.For(1, 1000000, (num) =>
            {

                channelDemo.Write($"这是第{(num)}条新闻");

            });

            // 发送完后才进行监听
            channelDemo.BeginListener();
        }
    }
}
