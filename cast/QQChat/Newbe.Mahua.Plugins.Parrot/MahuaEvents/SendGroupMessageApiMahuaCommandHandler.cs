using Autofac;
using Newbe.Mahua.MahuaEvents;
using Newbe.Mahua.Messages;
using Newbe.Mahua.Plugins.Parrot.CusTools;
using Newtonsoft.Json;
using NLog;

namespace Newbe.Mahua.Samples.ApiExtensions.MahuaApis
{
    /// <summary>
    /// 发送群消息
    /// </summary>
    public class SendGroupMessageApiMahuaCommandHandler
        : IGroupMessageReceivedMahuaEvent
    {
        private static Logger _logger = LogManager.GetLogger(nameof(SendGroupMessageApiMahuaCommandHandler));

        private readonly IMahuaApi _mahuaApi;

        public SendGroupMessageApiMahuaCommandHandler(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {
            _logger.Log(LogLevel.Info, $@"
[接收群消息][群号-{context.FromGroup}]
[{context.SendTime}] [{context.FromQq}]<{context.FromAnonymous}>
{context.Message}
");

            if (context.Message.Contains("function test"))
            {
                
                CatchTools.TryRun((() => { _mahuaApi.SetNotice(context.FromGroup, "测试群公告", "测试内容"); }));

                CatchTools.TryRun((() =>
                {
                    _mahuaApi.SendGroupMessage(context.FromGroup).Text("获取好友列表").Newline().Text(_mahuaApi.GetFriends()).Done();
                }));

                CatchTools.TryRun((() =>
                {
                    _mahuaApi.SendGroupMessage(context.FromGroup).Text("获取成员列表").Newline().Text(_mahuaApi.GetGroupMemebers(context.FromGroup)).Done();
                }));


                CatchTools.TryRun((() =>
                {
                    _mahuaApi.SendGroupMessage(context.FromGroup).Text("获取成员列表").Newline().Text(JsonConvert.SerializeObject(_mahuaApi.GetGroupMemebersWithModel(context.FromGroup))).Done();
                }));

                CatchTools.TryRun((() =>
                {
                    _mahuaApi.SendGroupMessage(context.FromGroup).Text("获取群列表").Newline().Text(JsonConvert.SerializeObject(_mahuaApi.GetGroupsWithModel())).Done();
                }));


            }
            
            _mahuaApi.SendGroupMessage(context.FromGroup)
                .Text($"{context.Message} ---要用复读打败复读机Face181.gif")
                .Done();

            // 异步发送消息，不能使用 _mahuaApi 实例，需要另外开启Session
//            Task.Factory.StartNew(() =>
//            {
//                using (var robotSession = MahuaRobotManager.Instance.CreateSession())
//                {
//                    var api = robotSession.MahuaApi;
//                    api.SendGroupMessage(context.FromGroup)
//                        //.At("2854196306")
//                        //.At("2854196310")
//                        //.At("2854196312")
//                        //.Newline()
//                        //.At(context.FromQq)
//                        //.Newline()
//                        .Text($"{context.Message} ---要用复读打败复读机Face182.gif")
//                        //.Newline()
//                        .Done();
//                }
//            });
        }
    }
}