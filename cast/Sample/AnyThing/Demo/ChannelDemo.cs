using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/9/2020 2:29:52 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ChannelDemo
    {
        private readonly int threadCount;
        private readonly CancellationToken token;

        private bool listener;

        private Channel<string> _channel;

        public ChannelDemo(int threadCount,CancellationToken token)
        {
            // 创建可由任意数量的读取器和编写器同时使用的无限通道。
            // 随便写 随便读
            _channel = Channel.CreateUnbounded<string>();
            this.threadCount = threadCount;
            this.token = token;

            if (threadCount < 1) threadCount = 1;// 至少要开一个task来充当接收器，不然msg没人看了,惨兮兮~

            //Enumerable.Range(0, threadCount).Select(u => Task.Factory.StartNew(Run, token, TaskCreationOptions.LongRunning, TaskScheduler.Default)).ToArray();// 借助linq构建Task

        }

        public void BeginListener()
        {
            if (!listener)
            {
                Enumerable.Range(0, threadCount).Select(u => Task.Factory.StartNew(Run, token, TaskCreationOptions.LongRunning, TaskScheduler.Default)).ToArray();// 借助linq构建Task
                listener = true;
            }
        }

        /// <summary>
        /// 写入：发消息给TA
        /// </summary>
        /// <param name="msg"></param>
        public void Write(string msg)
        {
            _channel.Writer.TryWrite(msg);

            //Console.WriteLine($"({Thread.CurrentThread.ManagedThreadId})[{DateTime.Now:hh:MM:ss fff}]write a msg");

        }

        static ISet<string> set = new HashSet<string>();

        /// <summary>
        /// TA的接收器
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task Run()
        {
            while (await _channel.Reader.WaitToReadAsync(token))// 一直等待消息过来
            {
                while (_channel.Reader.TryRead(out var msg))
                {
                    // 貌似不会出现多次读取的情况 这么nice吗？
                    // 通过查找源码 https://source.dot.net/#q=Channel，发现内部有锁机制(lock锁/自旋)保证同步性...
                    Console.WriteLine($"({Thread.CurrentThread.ManagedThreadId})[{DateTime.Now:hh:MM:ss fff}]receive a msg : {msg}");

                    //// 其他处理
                    //Thread.Sleep(100);

                    if (set.Contains(msg))
                    {
                        throw new Exception("重复执行了！");
                    }
                    set.Add(msg);
                }
            }
        }

    }
}
