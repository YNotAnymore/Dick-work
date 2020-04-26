using Common.CusAttribute;
using Newtonsoft.Json;
using Pikachu.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing
{

    [Customer]
    class Program
    {

        [return: Customer,Description]
        static void Main(string[] args)
        {

            //new ThreadDemo().Work();

            // 获取返回特性
            //var p = typeof(Program).GetMethod("Main",BindingFlags.NonPublic | BindingFlags.Static).ReturnTypeCustomAttributes.GetCustomAttributes(false);

            // .net 中的组件
            //Component component = new SqlConnection();

            //var obj = component.GetLifetimeService();

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        async void Run()
        {

            var info = Task.Run(() => { });

            await info;

        }

    }

}
