using Castle.DynamicProxy;
using Common.CusAttribute;
using Common.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
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

            // 闭包的概念:内层函数引用的外层函数的变量的最终值。
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => 
                {
                    Console.WriteLine(i);
                });
            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }


    }
}
