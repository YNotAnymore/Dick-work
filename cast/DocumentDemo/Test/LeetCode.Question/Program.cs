using LeetCode.Question.Hard;
using System;

namespace LeetCode.Question
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestDecomposition instance = new LongestDecomposition();

            //instance.Test(instance.Solution);

            //instance.TestCase(100, 10, instance.Solution);

            ParseBoolExpr instance = new ParseBoolExpr();


            Console.WriteLine(instance.Solution("&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))"));

            Console.WriteLine(instance.Solution("!(&(&(!(&(f)),&(t),|(f,f,t)),&(t),&(t,t,f)))"));

            Console.WriteLine(instance.Solution("|(f,&(t,t))") == true);

            instance.Test(instance.Solution);

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }
    }
}