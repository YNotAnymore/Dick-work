using System;
using System.Collections.Generic;

namespace CusLinq
{
    class Program
    {

        class A
        {
            public List<int> Where(Func<int,bool> func)
            {
                return new List<int>();
            }
        }

        static void Main(string[] args)
        {

            GC.TryStartNoGCRegion(int.MaxValue);

            var a = new A();

            // List<int> ss = a.Where((int item) => true);
            var ss = from item in a where true select item;

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }
}
