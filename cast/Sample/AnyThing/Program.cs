using AnyThing.Demo;
using AnyThing.SpeedTest;
using BenchmarkDotNet.Running;
using Castle.DynamicProxy;
using Command.Tools;
using Common.CusAttribute;
using Common.Extension;
using Perfolizer.Mathematics.Randomization;
using StackExchange.Redis;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing
{

    [Customer]
    public class Program
    {

        public static T GetDefault<T>() => default(T);

        [return: Customer, Description]
        static void Main(string[] args)
        {
            // Benchmark Test
            {
                //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ForeachTest>();

            }

            {
                CodeTimer timer = new CodeTimer();

                ForeachTest test = new ForeachTest();

                for (int i = 10; i < 20; i++)
                {
                    Console.WriteLine($@"{nameof(test.Normal)} time :
{timer.Time(i,test.Normal)}
");
                    Console.WriteLine($@"{nameof(test.NormalParallel)} time :
{timer.Time(i,test.NormalParallel)}
");
                    Console.WriteLine($@"{nameof(test.PartitionerParallel)} time :
{timer.Time(i,test.PartitionerParallel)}
");
                    Console.WriteLine("-------------------------");
                }

            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

    }
}
