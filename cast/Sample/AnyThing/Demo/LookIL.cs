using Common.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/23/2020 11:08:07 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class LookIL
    {

        public void Show()
        {
            object a = 2;

            //  IL_0008:  ldloc.0
            //  IL_0009: unbox.any ConsoleApp.Menu.LevelTypes
            //IL_000e:  stloc.1
            // 引用类型转值类型 : 拆箱 直接赋值
            LevelTypes level = (LevelTypes)a;

            //castclass  ConsoleApp.Program
            Program g = (Program)a;
        }

        public static void Show2()
        {

            string str = string.Empty;

            if (str + "" == "")
            {
                Console.WriteLine("is empty");
            }

        }

        public void Run()
        {
            // maxstack 预估使用的栈空间
            //int i = 1, j = 2;

            ////var k = i + j;

            //Console.WriteLine("-------");

            //Run3(1, 2, 3, 4);
            Run4(new[] { 1, 2, 3, 4 });

        }

        public void Run2()
        {

            int[] arr = { 1 };

        }

        public void Run3(int a, int b, int c, int d)
        {

        }

        public void Run4(int[] arr)
        {

        }

    }
}
