using System;
using System.Threading.Tasks;
using Simple.OData.Client;

namespace OdataStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        public async Task Test()
        {
            
            ODataClient client = new ODataClient("http://localhost:250");

            var list = await client.For("Users").FindEntriesAsync();

        }
        
    }
}
