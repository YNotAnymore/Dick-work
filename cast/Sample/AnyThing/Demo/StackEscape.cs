using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                        Console.WriteLine(k);// 正常输出
                    });

                    //Task.Delay(1).Wait();

                    //Console.WriteLine("sa");// io阻塞

                }//i销毁
            }
            {
                var i = 1000;
                Console.WriteLine($"xxx{i}");
            }

            {
                // 闭包的概念:内层函数引用的外层函数的变量的最终值。
                for (int i = 0; i < 10; i++)
                {
                    Task.Run(() =>
                    {
                        Console.WriteLine(i);
                    });
                }
            }

            //int i = 0; error

            //List<int> list = new List<int>();

            //for (int i = 0; i < 2;)
            //{
            //    Task.Run(() =>
            //    {
            //        Console.WriteLine(i++);
            //    });
            //    list.Add(i);
            //}

            //Console.WriteLine($"count:{list.Count}");

            {
                //int a = 0;

                //var rand = new Random();

                //for (int i = 0; i < 10; i++)
                //{
                //    new Thread(new ThreadStart(() =>
                //    {
                //        Thread.Sleep(100);

                //        Console.WriteLine($"current a : {a}");
                //        a++;
                //        Console.WriteLine($"next a should be : {a}");

                //    })).Start();
                //}
            }

        }
    }
}
