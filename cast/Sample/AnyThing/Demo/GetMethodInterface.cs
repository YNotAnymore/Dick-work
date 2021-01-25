using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/25/2021 12:15:13 PM
    /// @source : 获取方法的父类的信息
    /// @des : 
    /// </summary>
    public class GetMethodInterface 
    {

        public static void Run()
        {
            var type = typeof(Special);

            //MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var item in methodInfos)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine($"{item.DeclaringType.FullName}.{item.Name}({})");
            //}

            MethodInfo methodInfo = typeof(IActivity).GetMethod("Start",BindingFlags.Public|BindingFlags.Instance);

        }

    }

    public interface IActivity
    {
        void Start();
    }
    public interface IPrint
    {
        void Print();
    }

    public class Special : IActivity, IPrint
    {
        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }

}
