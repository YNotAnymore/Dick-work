using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Simple.OData.Client;

namespace OdataStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        public static async Task Test()
        {
            ODataClient client = new ODataClient(new ODataClientSettings()
            {
                BaseUri = new Uri("http://localhost:250/odata/"),
                OnTrace = ((s, objects) => { Console.WriteLine(s, objects); }),
            });

            //var list = await client.For("Users")
            //    .Key(1)
            //    //.Filter(u => (int)u["UserID"] == 1)
            //    .FindEntriesAsync();

            //Console.WriteLine(JsonConvert.SerializeObject(list));

            //list = await client.For("Users")
            //    .OrderBy(u => u["UserID"])
            //    .Key(3)
            //    .FindEntriesAsync();

            //Console.WriteLine(JsonConvert.SerializeObject(list));

            var ctx = await client.For("Users").Filter("UserID eq 1").Key(3).GetCommandTextAsync();

            Console.WriteLine(ctx);

            var list = await client.For("Users").Filter("UserID eq 1").FindEntriesAsync();

            Console.WriteLine(JsonConvert.SerializeObject(list));

        }
    }
}