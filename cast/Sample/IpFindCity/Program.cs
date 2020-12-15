using IP2Region;
using System;
using System.Text;

namespace IpFindCity
{
    class Program
    {
        static void Main(string[] args)
        {

            IP2Region.DbSearcher dbSearcher = new DbSearcher("config_data/ip2region.db");

            var ips = new[]
            {
                "94.169.199.159",
                "127.0.0.1",
                "218.250.143.72",
                "113.87.119.118",
                "::1"
            };

            foreach (var item in ips)
            {
                //IP2Region.Models.DataBlock dataBlock = dbSearcher.BinarySearch(item);
                Console.WriteLine($"\n\n当前查找ip:{item}");
                IP2Region.Models.DataBlock dataBlock = dbSearcher.BinarySearch(item);
                Console.WriteLine("BinarySearch:" + dataBlock);
                Console.WriteLine("after format:" + GetPosition(dataBlock.Region));
                //Console.WriteLine("BtreeSearch:" + dbSearcher.BtreeSearch(item));
            }

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        static string GetPosition(string str)
        {
            // 参考 : 中国|0|香港|0|电讯盈科
            int lineCount = 0;
            StringBuilder builder = new StringBuilder();
            bool beforeIsChar = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '|')
                {
                    if (lineCount == 3) break;
                    if(beforeIsChar)
                        builder.Append(' ');
                    lineCount++;
                    beforeIsChar = false;
                }
                else if (str[i] == '0') continue;
                else
                {
                    builder.Append(str[i]);
                    beforeIsChar = true;
                }
            }

            return builder.ToString();
        }

    }
}
