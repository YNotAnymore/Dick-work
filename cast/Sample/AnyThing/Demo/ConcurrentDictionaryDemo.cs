using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/17/2020 6:50:55 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ConcurrentDictionaryDemo
    {

        private ConcurrentDictionary<string, ISet<string>> dic = new ConcurrentDictionary<string, ISet<string>>();

        // 速度更快，无异常
        // 速度快->扩容更快...【don't konw why】
        public async Task Run2()
        {

            List<Task> list = new List<Task>();
            List<Task> list2 = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var copy = i.ToString();
                list.Add(Task.Run(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        var empty = j.ToString();
                        list2.Add(Task.Run(() =>
                        {
                            try
                            {
                                dic.AddOrUpdate(copy, new HashSet<string>() { empty }, (key, value) =>
                                {
                                    value.Add(empty);
                                    return value;
                                });
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.WriteLine(dic); // error : key not found
                            }
                        }));
                    }

                }));
            }

            await Task.WhenAll(list);
            await Task.WhenAll(list2);

            //Console.WriteLine(JsonConvert.SerializeObject(dic));

        }

        public async Task Run()
        {

            List<Task> list = new List<Task>();
            List<Task> list2 = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var copy = i.ToString();
                list.Add(Task.Run(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        var empty = j.ToString();
                        list2.Add(Task.Run(() =>
                        {
                            try
                            {
                                if (dic.ContainsKey(copy)) dic[copy].Add(empty);
                                //else dic.TryAdd(copy, new HashSet<string>() { empty });
                                // 需要设置初始容量不然容易有一个出现容量异常...
                                else dic.TryAdd(copy, new HashSet<string>(100) { empty });
                            }
                            // {"Index was outside the bounds of the array."}
                            // {"HashSet capacity is too big."}
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                Console.WriteLine(dic);
                            }
                        }));
                    }

                }));
            }

            await Task.WhenAll(list);
            await Task.WhenAll(list2);

            //Console.WriteLine(JsonConvert.SerializeObject(dic));

        }

    }
}
