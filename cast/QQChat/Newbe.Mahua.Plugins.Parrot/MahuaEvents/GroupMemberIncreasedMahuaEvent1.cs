using Newbe.Mahua.MahuaEvents;
using System;

namespace Newbe.Mahua.Plugins.Parrot.MahuaEvents
{
    /// <summary>
    /// 群成员增多事件
    /// </summary>
    public class GroupMemberIncreasedMahuaEvent1
        : IGroupMemberIncreasedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMemberIncreasedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMemberIncreased(GroupMemberIncreasedContext context)
        {

            _mahuaApi.SendGroupMessage(context.FromGroup)
                .At(context.JoinedQq)
                .Image("https://images7.alphacoders.com/305/thumb-350-305885.jpg")
                .Text("欢迎加入xxx")
                .Done();

            // todo 填充处理逻辑
            //throw new NotImplementedException();

            // 不要忘记在MahuaModule中注册
        }
    }
}
