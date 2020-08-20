using Common.CusAttribute;
using Microsoft.International.Converters.PinYinConverter;
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

    public class SingleData<T>
    {
        public T Data { get; set; }
    }

    [Customer]
    public class Program : IThing
    {

        [return: Customer, Description]
        static async Task Main(string[] args)
        {

            {

                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000");

                Console.WriteLine(connectionMultiplexer.GetType().Name);

                IDatabase database = connectionMultiplexer.GetDatabase();

                var key = $"h5.user.token.9b9091a27ae54e59b0344c2e62270286";

                //for (int i = 0; i < 10; i++)
                //{
                //    database.SortedSetAdd(key, i, (DateTime.Now.AddSeconds(2 + i) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
                //}

                //database.KeyExpire(key, TimeSpan.FromSeconds(5));

                //// 清空至最后一个                                                                                                                                                                                                                                                                                                                                       
                //long len = database.SortedSetLength(key);

                //database.SortedSetRemoveRangeByRank(key, 0, 0);

                //database.SortedSetRemoveRangeByRank(key, 0, 4);

                Console.WriteLine("存活的value:");
                var sortedSetEntries = database.SortedSetRangeByRankWithScores(key);

                foreach (var item in sortedSetEntries)
                {
                    Console.WriteLine($"{item.Element}-{item.Score}\n");
                }

                //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjAxZDJkYzNmMGMyNjRiMzk4MDllNTUwZjQ5MzRkYzA2IiwiVGVhbUlkIjoiZGIwZWNiZjM4NDg0NDRkZTk3OTQyZjEyZGUyYWFhMjIiLCJBdXRoU291cmNlIjoiQ3VzdG9tZSIsIlNvdXJjZSI6IldlYiIsImV4cCI6MTU5Nzk3NDE5MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIn0.TInjfwyuaKPbYKw2bpmjfLnzs0QeIIg_VkeTKLIfjTc";

                //bool result = database.SortedSetScanAsync(key, token).GetAsyncEnumerator().MoveNextAsync().Result;

                //Console.WriteLine(result);

                //for (int i = 0; i < 10; i++)
                //{
                //    double score = (DateTime.Now.AddSeconds(5) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
                //    Console.WriteLine("存活的value:");
                //    SortedSetEntry[] sortedSetEntries = database.SortedSetRangeByScoreWithScores(key, score);

                //    foreach (var item in sortedSetEntries)
                //    {
                //        Console.WriteLine($"{item.Element}-{item.Score}");
                //    }
                //    Thread.Sleep(1000);
                //}

                //long v = database.SortedSetLengthByValue(key, "1", "1");

                //Console.WriteLine(v);

                //Console.WriteLine(database.SortedSetRemove(key, "1"));

                //while (true)
                //{

                //    double score = (DateTime.Now.AddSeconds(5) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;

                //    Console.WriteLine(score);

                //    SortedSetEntry[] sortedSetEntries = database.SortedSetRangeByScoreWithScores(key, 0, score);

                //    if (sortedSetEntries == null || sortedSetEntries.Length == 0) continue;

                //    foreach (var item in sortedSetEntries)
                //    {
                //        Console.WriteLine($"{item.Element}-{item.Score}");
                //    }

                //    database.SortedSetRemoveRangeByScore(key, 0, score);

                //    break;

                //}

                //v = database.SortedSetLengthByValue(key, "1", "1");

                //Console.WriteLine(v);

                //Console.WriteLine(database.SortedSetRemove(key,"1"));

                //Console.WriteLine("存活的value:");

                //RedisValue[] redisValues = database.SortedSetRangeByRank(key);

                //foreach (var item in redisValues)
                //{
                //    Console.WriteLine($"{item}");
                //}
                //database.KeyDelete(key);

                Console.WriteLine((DateTime.Now.AddMinutes(3) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);

            }

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

        private const int _diff = 'a' - 'A';

        public static char UpperToLower(char c)
        {
            if (c >= 'a')
                return c;
            return (char)(c + _diff);
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
