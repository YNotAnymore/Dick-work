using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace AnyThing
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = "{\"data\":1}";

            var empty = JsonConvert.DeserializeObject<string>(data);

            Console.WriteLine(empty);

            var str = System.Text.Json.JsonSerializer.Deserialize<string>(data);

            Console.WriteLine(data);

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }
}
