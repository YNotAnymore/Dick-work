using LanghuaNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FrameTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new LanghuaContent())
            {

                context.Database.Create();
                
                if (context.Database.CreateIfNotExists())
                {
                    Console.WriteLine("数据库已创建成功！");
                }
                
                Console.WriteLine("--------");
            }

            Console.ReadKey(true);

        }
    }
}
