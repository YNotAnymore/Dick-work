using AnyThing.Demo;
using Common.CusAttribute;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing
{

    [Customer]
    class Program
    {

        [return: Customer, Description]
        static void Main(string[] args)
        {

            int i = 1;

            i = i++;

            int j = i;

            Console.WriteLine(j);

            Console.WriteLine(i);

            var param = "{\"SupplierUserID\":42,\"SupplierNickName\":\"TH\",\"OrderID\":37653,\"OpenID\":\"o4odp0_igG7nwgXzIgCM5cmEsu_c\",\"supplierStrNewState\":\"新订单\",\"cnItemName\":\"土豪船皇帝岛一日游\",\"OrderNo\":\"202005141059017653\",\"Title\":\"您好，您有一条订单等待处理。\\r\\n \",\"Remark\":\" \\r\\n 请及时登录系统后台进行处理，谢谢！\"} ";

            var evt = System.Text.Json.JsonSerializer.Deserialize<OrderSendSupplierWxConfirm_LtgEvt>(param,new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }

        public class OrderSendSupplierWxConfirm_LtgEvt
        {
            public string OrderNo { get; set; }
            public int OrderID { get; set; }
            public string SupplierStrNewState { get; set; }
            public string cnItemName { get; set; }
            public string OpenID { get; set; }
            public string SupplierNickName { get; set; }
            public int SupplierUserID { get; set; }
            public string Title { get; set; }
            public string Remark { get; set; }
        }

        private static void TestChannelDemo()
        {
            CancellationToken token = new CancellationToken();

            //// TA别读太快了，弄1个task读
            //ChannelDemo channelDemo = new ChannelDemo(1, token);

            // 发得有点快，你多弄几个收吧
            ChannelDemo channelDemo = new ChannelDemo(10, token);

            //// 单线程发100次
            //for (int i = 0; i < 100; i++)
            //{
            //    channelDemo.Write($"这是第{(i + 1)}条消息");
            //}

            //// 等待0.5s后发送
            //Thread.Sleep(500);

            // 并发发送
            Parallel.For(1, 1000000, (num) =>
            {

                channelDemo.Write($"这是第{(num)}条新闻");

            });

            // 发送完后才进行监听
            channelDemo.BeginListener();
        }
    }
}
