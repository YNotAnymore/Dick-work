using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestSpeed.Model;
using TestSpeed.RefData;
using TestSpeed.Test;
using TestSpeed.Tools;

namespace TestSpeed
{
    class Program
    {

        [MyAspect]
        public static void Show(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {

            Show("first");

            Show("123");

            Console.ReadKey(true);

            TestLinqJoin();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dynamic txt = null;

            if (txt != null & txt != 0)
            {
                Console.WriteLine(txt);
            }

            Console.ReadKey(true);

            List<dynamic> list = new List<dynamic>();

            var dataCount = 100;

            var randCount = 100;

            var tryCount = 10;

            var rand = new Random();

            var timer = new CodeTimer();
            CodeTimerResult codeTimerResult;
            timer.Initialize();

            List<TxtModel> res = null;

            for (int i = 0; i < dataCount; i++)
            {
                var text = Guid.NewGuid().ToString();
                for (int j = 0; j < rand.Next(randCount); j++)
                {
                    list.Add(new {Text = text});
                }
            }

            timer.Time(1, (() =>
            {
                DistinctTest.ListSolution(list);
                DistinctTest.SetSolution(list);
                DistinctTest.DictionarySolution(list);

                Console.WriteLine("----");
            }));

            codeTimerResult = timer.Time(tryCount, (() => res = DistinctTest.ListSolution(list)));
            Console.WriteLine($"ListSolution : {codeTimerResult} res : {res.Count}");

            codeTimerResult = timer.Time(tryCount, (() => res = DistinctTest.SetSolution(list)));
            Console.WriteLine($"SetSolution : {codeTimerResult} res : {res.Count}");

            codeTimerResult = timer.Time(tryCount, (() => res = DistinctTest.DictionarySolution(list)));
            Console.WriteLine($"DictionarySolution : {codeTimerResult} res : {res.Count}");

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        private static void TestLinqJoin()
        {
            var list = Enumerable.Range(0, 10);

            var newList = Enumerable.Range(5, 20);

            var res = from a in list
                join i in newList on a equals i into temp
                from tt in temp.DefaultIfEmpty()
                select new {a, tt};

            Console.WriteLine(JsonConvert.SerializeObject(res));

            Console.ReadKey(true);
        }
    }
}