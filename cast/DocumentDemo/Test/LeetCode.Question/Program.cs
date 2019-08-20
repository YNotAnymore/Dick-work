using LeetCode.Question.Hard;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeetCode.Question
{
    class Program
    {
        static void Main(string[] args)
        {
            BraceExpansionII instance = new BraceExpansionII();

            var res = instance.Solution("{a,b}{c,{d,e}}");

            Console.WriteLine(JsonConvert.SerializeObject(res));

            res = instance.Solution("{{a,z},a{b,c},{ab,z}}");

            Console.WriteLine(JsonConvert.SerializeObject(res));

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        private static void TestLongestDecomposition()
        {
            LongestDecomposition instance = new LongestDecomposition();

            instance.Test(instance.Solution);

            instance.TestCase(100, 10, instance.Solution);
        }

        private static void TestParseBoolExpr()
        {
            ParseBoolExpr instance = new ParseBoolExpr();

            Console.WriteLine(instance.Solution("|(f,&(t,t))") == true);

            instance.Test(instance.Solution);

            Console.WriteLine(instance.Solution("!(&(&(!(&(f)),&(t),|(f,f,t)),&(t),&(t,t,f)))"));

            Console.WriteLine(instance.Solution(
                                  "&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))") ==
                              false);
        }

        private static void TestMyCalendarThree()
        {
            List<int> list = new List<int>() {1, 2, 3};
            list.Insert(0, 4);

            MyCalendarThree instance = new MyCalendarThree();

            instance.Test();

            var arr = new[]
            {
                new[] {24, 40},
                new[] {43, 50},
                new[] {27, 43},
                new[] {5, 21},
                new[] {30, 40},
                new[] {14, 29},
                new[] {3, 19},
                new[] {3, 14},
                new[] {25, 39},
                new[] {6, 19}
            };

            //[null,1,1,2,2,3,3,3,3,4,4]

            foreach (var item in arr)
            {
                instance.Book(item[0], item[1]);
            }
        }
    }
}