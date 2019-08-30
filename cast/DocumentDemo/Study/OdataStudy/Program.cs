using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Simple.OData.Client;
using Vlxm.LH.Data;

namespace OdataStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            ODataClient client = new ODataClient(new ODataClientSettings()
            {
                BaseUri = new Uri("http://www.langhua.service/odata/"),
                OnTrace = ((s, objects) => { Console.WriteLine(s, objects); }),
            });

            var res = client.For<Order>().Key(3).Filter(u => u.CreateTime < DateTime.Now).FindEntriesAsync().Result;

            Test(client);

            Console.WriteLine(JsonConvert.SerializeObject(res));

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        public static async Task Test(ODataClient client)
        {
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