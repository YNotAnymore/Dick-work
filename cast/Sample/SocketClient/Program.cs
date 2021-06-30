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

        static async Task Main(string[] args)
        {

            Console.WriteLine("请输入服务端域名：");

            //CommonConst.DomainName = Console.ReadLine().Trim();
            CommonConst.DomainName = "";

            //await clientWebSocket.SendTxtMsgAsync();

            Random random = new Random();
            { // 单会话发送

                //_ = StartClient("17078539106", "b2228fff7fee459b99ae0c67d8caf117", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539100", "d1df1fd71fae48409fa676421ed8c62e", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539108", "127f5c4fc56a4759ad3fae6a092414c1", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539147", "4a11b51e42084ff48cd2ff4abd60f6ae", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539095", "d4317553c0434642b5d9360dd6a56a98", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539116", "a8d5c41fac5045e7847f870ef37b012a", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539099", "3b9f7940632e43fa8a91a0b926b36706", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                //_ = StartClient("17078539125", "c892625131dc4e2e9f48134821ab604b", () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);

            }
            { // 多会话发送

                var phoneMapSessions = File.ReadAllText(@"F:\Davis\Data\test\phoneMapSessions.txt");

                Dictionary<string, List<string>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(phoneMapSessions);

                Console.WriteLine($"次数连接数：{dictionary.Count}");

                //for (int i = 0; i < 5; i++)
                {
                    foreach (var item in dictionary)
                    {
                        _ = StartClient(item.Key, item.Value, () => LargeData.LargetArr[random.Next(LargeData.LargetArr.Length)]);
                    }
                }

            }
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

            await clientWebSocket.ConnectAsync(new Uri($"wss://{CommonConst.DomainName}/msgapi/chatHub?id={commonRes1.Res}&access_token={commonRes.Res}"), CancellationToken.None);

            Console.WriteLine("连接socket成功");

            await clientWebSocket.SendInitAsync();

            Console.WriteLine("发送初始消息成功");

            _ = clientWebSocket.SubscribeAsync(100, $"{phone}-{sessionIds}");

            foreach (var sessionId in sessionIds)
            {
                _ = clientWebSocket.WhileSendTxtMsgAsync(10 * 1000, sessionId, getContentFunc, getSendCountFunc);
            }
        }


        private static async Task StartClient(string phone, string sessionId, Func<string> getContentFunc, Func<int> getSendCountFunc = null)
        {

            HttpClient client = new HttpClient();

            CommonRes commonRes = await AuthUtils.GetToken(client, phone);

            if (!commonRes.Success) return;

            CommonRes commonRes1 = await AuthUtils.GetConnectionToken(client, commonRes.Res);

            if (!commonRes1.Success) return;

            ClientWebSocket clientWebSocket = new ClientWebSocket();

            await clientWebSocket.ConnectAsync(new Uri($"wss://{CommonConst.DomainName}/msgapi/chatHub?id={commonRes1.Res}&access_token={commonRes.Res}"), CancellationToken.None);

            await clientWebSocket.SendInitAsync();

            _ = clientWebSocket.SubscribeAsync(100);

            _ = clientWebSocket.WhileSendTxtMsgAsync(10 * 1000, sessionId, getContentFunc, getSendCountFunc);
        }

    }
}
