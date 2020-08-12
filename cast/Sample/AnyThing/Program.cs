using Common.CusAttribute;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace AnyThing
{

    [Customer]
    public class Program : IThing
    {

        static int numA;

        static readonly int numB;

        const int numC = 1;

        private const int _diff = 'a' - 'A';

        public static char UpperToLower(char c)
        {
            if (c >= 'a')
                return c;
            return (char)(c + _diff);
        }

        [return: Customer, Description]
        static async Task Main(string[] args)
        {

            {
                //XPathDocument xml = new XPathDocument(@"F:\WorkSpace\UA_Foundation\Application\ZeusSys.AdminApi\bin\Debug\netcoreapp3.1\ZeusSys.AdminApi.xml");

                //XPathNavigator navigator = xml.CreateNavigator();

                //StringBuilder builder = new StringBuilder();

                //foreach (var item in typeof(MemberRes).GetProperties())
                //{
                //    var name = $"{UpperToLower(item.Name[0])}{item.Name.Substring(1)}";
                //    var desc = navigator.SelectSingleNode($"doc/members/member[@name='P:ZeusSys.AdminApi.Domain.MemberModule.Response.MemberRes.{item.Name}']/summary")?.Value.Replace('\n', ' ').Trim() ?? name;

                //    builder.AppendLine($"{name}: '{desc}',");
                //}

                //Console.WriteLine(builder);
                //XPathNavigator xPathNavigator = navigator.SelectSingleNode("doc/members/member[@name='P:ZeusSys.AdminApi.ConfigModel.JwtBearerConfig.TokenValidTime']/summary");

                //Console.WriteLine(xPathNavigator.Value);

            }

            //TimeSpan timeSpan = TimeSpan.FromMinutes(120);

            //Console.WriteLine(timeSpan.ToString(@"hh\:mm"));

            //{

            //    await Task.Run(() => { Console.WriteLine("await"); });

            //    Task.Run(() => { Console.WriteLine("wait"); }).Wait();

            //}

            // Benchmark Test
            {
                //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ForeachTest>();

            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }


        private static void TestRedis()
        {
            // test redis get thread error

            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000");

            Console.WriteLine(connectionMultiplexer.GetType().Name);

            IDatabase database = connectionMultiplexer.GetDatabase();

            Console.WriteLine(database.GetType().Name);

            var key = "test.key";

            //StringBuilder max = new StringBuilder();

            //for (int i = 0; i < 5965220; i++)
            //{
            //    max.Append(Guid.NewGuid().ToString());
            //}

            //var maxStr = max.ToString();

            //bool res = database.StringSet(key, $"{Guid.NewGuid().ToString()}-{maxStr}");

            //Console.WriteLine("set key res : " + res);

            bool flag = true;

            ThreadPool.SetMinThreads(100, 0);

            Parallel.For(0, 200_000, (num) =>
            {
                try
                {
                    if (flag)
                    {
                        //ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000").GetDatabase().StringGet(key);
                    }
                }
                catch (Exception e)
                {

                    flag = false;

                    Console.WriteLine(e.ToString());

                    //Thread.Sleep(3000);

                    //RedisValue redisValue = database.StringGet(key);

                    //Console.WriteLine(redisValue.Length());
                }
            });

        }

        private static void CreateDelegate()
        {
            IThing instance = new Program();

            MethodInfo methodInfo = instance.GetType().GetMethod("Show");

            Delegate @delegate = instance.GetType().GetMethod("Show")
                .CreateDelegate(typeof(Action<string>), instance);

            Action<string> action = (Action<string>)@delegate;

            action("12312");

        }

        public void Show(string str)
        {
            Console.WriteLine(str);
        }

    }

    public interface IThing
    {
        void Show(string str);
    }


}
