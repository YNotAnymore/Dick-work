using System;
using Newtonsoft.Json;

namespace Consoles.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 16:53:25
    /// @source : 
    /// @des : 
    /// </summary>
    public class ShowResult
    {

        public static void Show<T>(Func<T> func)
        {
            Show(func());
        }
        
        public static void Show<T>(T data)
        {
            System.Console.WriteLine("----------------S------------------");
            if (typeof(T).IsValueType)
                System.Console.WriteLine(data.ToString());
            else
                System.Console.WriteLine(JsonConvert.SerializeObject(data));
            System.Console.WriteLine("----------------E------------------");
        }

    }
}
