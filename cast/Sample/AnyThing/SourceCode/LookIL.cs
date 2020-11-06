using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.SourceCode
{
    /// <summary>
    /// @auth : monster
    /// @since : 10/29/2020 6:46:34 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class LookIL
    {

        public void Test3(int num)
        {
            int a, b;
            a = b = num;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        public void Test()
        {
            var arr = new[] { 1, 2, 3 };
            Console.WriteLine(arr[0]);
            arr[0] = 10;

            int num = arr[^1]; // 只是编辑器语法，IL都差不多...
            Console.WriteLine(num);
        }

        public void Test2()
        {
            var arr = new[] { 1, 2, 3 };
            Console.WriteLine(arr[0]);
            arr[0] = 10;

            int num = arr[arr.Length - 1];
            Console.WriteLine(num);
        }

    }
}

