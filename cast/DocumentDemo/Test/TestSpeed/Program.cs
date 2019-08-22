using System;
using System.Collections.Generic;
using System.Linq;
using TestSpeed.Model;
using TestSpeed.Test;
using TestSpeed.Tools;

namespace TestSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
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

    }
}