﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/23/2020 11:06:17 AM
    /// @source : 
    /// @des : 逃逸
    /// </summary>
    public class StackEscape
    {
        void Demo()
        {
            {
                for (int i = 0; i < 100; i++)
                {
                    //if (i > 0) break;
                    //Task.Run(() => { Console.WriteLine("一"); });
                    //Task.Run(() => { Console.WriteLine("二"); });
                    var k = i;
                    Task.Run(() =>
                    {
                        //Thread.Sleep(1000);
                        //Console.WriteLine($"{i}-{Thread.CurrentThread.ManagedThreadId}");// 栈逃逸
                        //Console.WriteLine($"{i++}");// 栈逃逸
                        // 加wait仍然会出现新线程
                        //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                        Console.WriteLine(k);
                    });

                    //Task.Delay(1).Wait();

                    //Console.WriteLine("sa");// io阻塞

                }//i销毁
            }
            {
                var i = 1000;
                Console.WriteLine($"xxx{i}");
            }
            //int i = 0; error

        }
    }
}
