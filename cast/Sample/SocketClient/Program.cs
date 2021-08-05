using Newtonsoft.Json;
using SignalR.SocketClientDemo.Model;
using SignalR.SocketClientDemo.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using Common.Extension;
using SignalR.SocketClientDemo.Data;
using System.IO;
using System.Collections.Generic;

namespace SignalR.SocketClientDemo
{
    class Program
    {

        /**
         * SignalR websocket 客户端示例
         */

        static Random random = new Random();
        static string GetRandContent()
        {
            var txt = LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)];

            txt = txt.Replace("\"", string.Empty)
                .Replace("，", string.Empty)
                .Replace("！", string.Empty)
                .Replace(",", string.Empty)
                .Replace("。", string.Empty);

            var len = Math.Min(random.Next(4) + 2, txt.Length);
            var start = random.Next(txt.Length - len);
            var randName = txt.Substring(start, len);
            return randName;

        }

        static async Task Main(string[] args)
        {

            Console.WriteLine("请输入服务端域名：");

            //CommonConst.DomainName = Console.ReadLine().Trim();
            //CommonConst.DomainName = File.ReadAllText(@"F:\Davis\Data\test\txt\site.txt");
            CommonConst.DomainName = "192.168.0.118:5000";
            CommonConst.IsHttps = false;

            //await clientWebSocket.SendTxtMsgAsync();

            { // 单会话发送
                _ = StartClient("17078539173", "a0b6eb7a79fc4d8384bcaf9350d3367d", GetRandContent);
                //_ = StartClient("17078539163", "a0b6eb7a79fc4d8384bcaf9350d3367d", GetRandContent);
            }
            //{ // 多会话发送

            //    var phoneMapSessions = File.ReadAllText(@"F:\Davis\Data\test\phoneMapSessions.txt");

            //    Dictionary<string, List<string>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(phoneMapSessions);

            //    Console.WriteLine($"连接次数：{dictionary.Count}");

            //    //for (int i = 0; i < 5; i++)
            //    {
            //        foreach (var item in dictionary)
            //        {
            //            _ = StartClient(item.Key, item.Value, () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
            //        }
            //    }

            //}
            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }


        private static async Task StartClient(string phone, List<string> sessionIds, Func<string> getContentFunc, Func<int> getSendCountFunc = null)
        {

            HttpClient client = new HttpClient();

            CommonRes commonRes = await AuthUtils.GetToken(client, phone);

            if (!commonRes.Success) return;

            Console.WriteLine("获取登录token成功：" + commonRes.Res);

            CommonRes commonRes1 = await AuthUtils.GetConnectionToken(client, commonRes.Res);

            if (!commonRes1.Success) return;
            Console.WriteLine("获取连接授权token成功：" + commonRes1.Res);

            ClientWebSocket clientWebSocket = new ClientWebSocket();

            await clientWebSocket.ConnectAsync(new Uri($"ws{(CommonConst.IsHttps ? "s" : "")}://{CommonConst.DomainName}/msgapi/chatHub?id={commonRes1.Res}&access_token={commonRes.Res}"), CancellationToken.None);

            Console.WriteLine("连接socket成功");

            await clientWebSocket.SendInitAsync();

            Console.WriteLine("发送初始消息成功");

            _ = clientWebSocket.SubscribeAsync(100, $"{phone}-{sessionIds}");

            //foreach (var sessionId in sessionIds)
            //{
            //    _ = clientWebSocket.WhileSendTxtMsgAsync(10 * 1000, sessionId, getContentFunc, getSendCountFunc);
            //}
        }


        private static async Task StartClient(string phone, string sessionId, Func<string> getContentFunc, Func<int> getSendCountFunc = null)
        {
            try
            {
                HttpClient client = new HttpClient();

                CommonRes commonRes = await AuthUtils.GetToken(client, phone);

                if (!commonRes.Success) return;

                CommonRes commonRes1 = await AuthUtils.GetConnectionToken(client, commonRes.Res);

                if (!commonRes1.Success) return;

                ClientWebSocket clientWebSocket = new ClientWebSocket();

                await clientWebSocket.ConnectAsync(new Uri($"ws{(CommonConst.IsHttps ? "s" : "")}://{CommonConst.DomainName}/msgapi/chatHub?id={commonRes1.Res}&access_token={commonRes.Res}"), CancellationToken.None);

                await clientWebSocket.SendInitAsync();

                _ = clientWebSocket.SubscribeAsync(100);

                //_ = clientWebSocket.WhileSendTxtMsgAsync(5 * 1000, sessionId, getContentFunc, getSendCountFunc);
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
