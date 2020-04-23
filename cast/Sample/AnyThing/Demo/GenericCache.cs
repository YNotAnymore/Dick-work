using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/23/2020 11:07:06 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class GenericCache
    {

        class Fly<T>
        {

            static string data;

            static Fly()
            {// 泛型缓存
                data = $"Fly create by {typeof(T).Name}";
            }

        }

    }
}
