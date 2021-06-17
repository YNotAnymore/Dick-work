using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SignalR.SocketClientDemo.Data;
using SignalR.SocketClientDemo.Model;

namespace SignalR.SocketClientDemo.Utils
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 11:14:35 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class SignalRClientWebSocketUtils
    {

        public static string GetInvocationId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static ConcurrentDictionary<string, Func<MsgInfo, Task>> CallBackFunc = new ConcurrentDictionary<string, Func<MsgInfo, Task>>();

        /// <summary>
        /// 发送初始消息，告知消息协议+版本
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Task SendInitAsync(this ClientWebSocket client)
        {
            var msg = "{\"protocol\":\"json\",\"version\":1}" + CommonConst.EndCode;
            return client.SendAsync(Encoding.UTF8.GetBytes(msg), WebSocketMessageType.Binary, false, CancellationToken.None);
        }

        public static async Task SubscribeAsync(this ClientWebSocket client, int millisecondsDelay)
        {
            try
            {
                await InnerSubscribeAsync(client, millisecondsDelay);
            }
            catch (Exception e)
            {
                Console.WriteLine("监听异常：" + e);
            }
        }
        /// <summary>
        /// 监听消息接收
        /// </summary>
        /// <param name="client"></param>
        /// <param name="millisecondsDelay">监听间隔</param>
        /// <returns></returns>
        private static async Task InnerSubscribeAsync(this ClientWebSocket client, int millisecondsDelay)
        {
            while (client.State == WebSocketState.Open)
            {
                var result = new byte[1024];

                await client.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());// 接收数据

                var lastbyte = result.ByteCut(0x00);

                var str = Encoding.UTF8.GetString(lastbyte, 0, lastbyte.Length);

                string[] noticeArr = str.Split(CommonConst.EndCode);

                foreach (var item in noticeArr)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    MsgInfo msgInfo = JsonConvert.DeserializeObject<MsgInfo>(item);

                    if (msgInfo.Type == MsgType.Heartbeat) // 回复心跳
                    {
                        await client.SendAsync(lastbyte, WebSocketMessageType.Binary, false, CancellationToken.None);
                        Console.WriteLine("心跳消息");
                    }
                    else if (msgInfo.Type == MsgType.CallBack)
                    {
                        if (CallBackFunc.TryRemove(msgInfo.InvocationId, out var callbackFunc))
                        {
                            await callbackFunc(msgInfo);
                        }
                        else
                        {
                            Console.WriteLine($"[回执无订阅]接收到了一条消息：{item}");
                        }
                    }
                    else if (msgInfo.Type == MsgType.Notice)
                    {
                        if (msgInfo.Target == "NewMsg") // 接收到一条新消息
                        {
                            var info = msgInfo.Arguments[0];

                            NewMsgNotice newMsgNotice = JsonConvert.DeserializeObject<NewMsgNotice>(JsonConvert.SerializeObject(info));

                            if (!newMsgNotice.IsOwnerSend) // 自动已读
                            {
                                await InnerSendAsync(client, "MsgRead", new { newMsgNotice.SessionId });
                            }

                        }
                        else
                        {
                            Console.WriteLine($"[回执无处理]接收到了一条消息：{item}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"接收到了一条消息：{item}");
                    }
                }

                await Task.Delay(millisecondsDelay);
            }

            Console.WriteLine("连接终止了");

        }

        private static async Task InnerSendAsync(this ClientWebSocket client, string target, object arg, Func<MsgInfo, Task> callBackFunc = null)
        {
            string invocationId = GetInvocationId();

            var msg = new SendMsgInfo(new[] { arg }, invocationId, target);

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            string str = JsonConvert.SerializeObject(msg, jsonSerializerSettings) + CommonConst.EndCode;

            //str = "{\"arguments\":[{\"content\":\"测试消息\",\"sessionId\":\"b2228fff7fee459b99ae0c67d8caf117\"}],\"invocationId\":\"16232113211241al\",\"target\":\"SendTxtMsg\",\"type\":1,\"streamIds\":[]}";

            // 添加回执
            if (callBackFunc != null)
                CallBackFunc.TryAdd(invocationId, info =>
                {
                    if (!string.IsNullOrEmpty(info.Error))
                    {
                        Console.WriteLine("调用失败");
                    }
                    else
                    {
                        SimpleBaseRes baseRes = JsonConvert.DeserializeObject<SimpleBaseRes>(JsonConvert.SerializeObject(info.Result));

                        if (baseRes.IsSuccess())
                        {
                            Console.WriteLine("发送消息成功!");
                        }
                        else
                        {
                            Console.WriteLine("发送消息失败：" + baseRes.Desc);
                        }

                    }
                    return Task.CompletedTask;
                });

            await client.SendAsync(Encoding.UTF8.GetBytes(str), WebSocketMessageType.Binary, false, CancellationToken.None);

        }

        private static Random random = new Random();

        public static async Task WhileSendTxtMsgAsync(this ClientWebSocket client, int millisecondsDelay, string sessionId, Func<string> getContentFunc, Func<int> getSendCountFunc = null)
        {
            while (client.State == WebSocketState.Open)
            {
                await Task.Delay(millisecondsDelay);

                if (getSendCountFunc == null)
                {
                    await SendTxtMsgAsync(client, sessionId, getContentFunc);
                }
                else
                {
                    int v = getSendCountFunc();
                    for (int i = 0; i < v; i++)
                    {
                        await SendTxtMsgAsync(client, sessionId, getContentFunc);
                        await Task.Delay((random.Next(10) + 5) * 100);
                    }

                }
            }
        }

        private static async Task SendTxtMsgAsync(this ClientWebSocket client, string sessionId, Func<string> getContentFunc)
        {

            var arg = new
            {
                sessionId,
                content = getContentFunc()
            };

            await InnerSendAsync(client, "SendTxtMsg", arg, info =>
             {
                 if (!string.IsNullOrEmpty(info.Error))
                 {
                     Console.WriteLine("调用失败");
                 }
                 else
                 {
                     SimpleBaseRes baseRes = JsonConvert.DeserializeObject<SimpleBaseRes>(JsonConvert.SerializeObject(info.Result));

                     if (baseRes.IsSuccess())
                     {
                         Console.WriteLine("发送消息成功!");
                     }
                     else
                     {
                         Console.WriteLine("发送消息失败：" + baseRes.Desc);
                     }

                 }
                 return Task.CompletedTask;
             });

        }

    }
}
