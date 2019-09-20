using Newbe.Mahua.MahuaEvents;
using System;
using System.Threading.Tasks;

namespace Newbe.Mahua.Plugins.Parrot.MahuaEvents
{
    /// <summary>
    /// 来自好友的私聊消息接收事件
    /// </summary>
    public class PrivateMessageFromFriendReceivedMahuaEvent
        : IPrivateMessageFromFriendReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public PrivateMessageFromFriendReceivedMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessFriendMessage(PrivateMessageFromFriendReceivedContext context)
        {
            // todo 填充处理逻辑
            //throw new NotImplementedException();

            // 不要忘记在MahuaModule中注册

            //if (context.FromQq.Equals("1829784767"))
            //{
                // 戳一戳
                _mahuaApi.SendPrivateMessage(context.FromQq)
                    .Shake()
                    .Done();

                _mahuaApi.SendPrivateMessage(context.FromQq)
                .Text(context.Message)
                .Done();
            //}

            //// 嘤嘤嘤，换行，重复消息
            //_mahuaApi.SendPrivateMessage(context.FromQq)
            //    .Text(context.)
            //    .Newline()
            //    .Text(context.Message)
            //    .Done();

            //// 异步发送消息，不能使用 _mahuaApi 实例，需要另外开启Session
            //Task.Factory.StartNew(() =>
            //{
            //    using (var robotSession = MahuaRobotManager.Instance.CreateSession())
            //    {
            //        var api = robotSession.MahuaApi;
            //        api.SendPrivateMessage(context.FromQq, "异步回复");
            //    }
            //});

        }
    }
}
