using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<JProperty> propList = new List<JProperty>();
            var json = new JObject(
                propList
            );

            Console.ReadKey(true);


        }
    }
}
