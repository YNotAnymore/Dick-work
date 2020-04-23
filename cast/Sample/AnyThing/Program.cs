using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AnyThing
{
    [Customer]
    class Program
    {
        [return: Customer]
        static void Main(string[] args)
        {

            Component component = new SqlConnection();

            var obj = component.GetLifetimeService();

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }

}
