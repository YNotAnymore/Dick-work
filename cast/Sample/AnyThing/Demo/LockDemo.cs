using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/28 11:35:48
    /// @source : 
    /// @des : 
    /// </summary>
    public class LockDemo
    {
        /**
         * 
         * 锁的种类 : 排他锁--只能由一方单独获取  共享锁 -- 可以由多方共同获取 例如：可以共同查询
         * 
         */

        private object _lock = new object();
        private object _lock2 = new object();

        public void Run()
        {
            Thread thread = new Thread(MethodA);
            Thread thread2 = new Thread(MethodB);
            thread.Start();
            thread2.Start();
        }

        private void MethodA()
        {
            lock (_lock)
            {
                Thread.Sleep(500);
                lock (_lock2)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var info = _lock2.ToString();
                        Console.WriteLine(i + "，线程-" + Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }
        }

        private void MethodB()
        {
            lock (_lock2)
            {
                Thread.Sleep(500);
                lock (_lock)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var info = _lock.ToString();
                        Console.WriteLine(i + "，线程-" + Thread.CurrentThread.ManagedThreadId);
                    }
                }
            }
        }

        public void WaitAndSleep()
        {

            #region 让线程阻塞的方式

            {

                Task task = null, task2 = null;

                task = new Task(() =>
                {

                    // Pulse : 通知等待队列中的线程锁定对象状态的更改。

                    // Wait : 释放指定对象上的排他锁。

                    // lock 在finally中调用的是Exit而非Pulse
                    lock (_lock)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-over");

                        // √
                        Monitor.Pulse(_lock);
                    }

                    // 无效，此处非锁的拥有者
                    //Monitor.Pulse(_lock);
                });

                task2 = new Task(() =>
                {
                    lock (_lock)
                    {

                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-start");

                        // Sleep 不会释放锁
                        Thread.Sleep(300);

                        Console.WriteLine("sleep over");

                        // Wait释放了锁并阻塞当前线程
                        // 释放后会出现一直等待 why?
                        // 根据官方文档 ： 调用 Wait 的所有线程将保留在等待队列中，直到接收到由锁的所有者发送 Pulse 或 PulseAll发出的信号。
                        // 注意：由锁的所有者 所以必须要在锁的执行中 Pulse才有效
                        var status = Monitor.Wait(_lock);

                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-over");

                    }
                });

                task2.Start();

                Thread.Sleep(100);

                task.Start();

            }

            #endregion

        }

    }
}