using Newbe.Mahua.MahuaEvents;
using System;

namespace Newbe.Mahua.Plugins.Parrot.MahuaEvents
{
    /// <summary>
    /// 群成员减少事件
    /// </summary>
    public class GroupMemberDecreasedMahuaEvent1
        : IGroupMemberDecreasedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMemberDecreasedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMemberDecreased(GroupMemberDecreasedContext context)
        {

            var isAdminOpt = string.IsNullOrWhiteSpace(context.FromQq)?string.Empty: "[管理员操作]";

            _mahuaApi.SendGroupMessage(context.FromGroup)
               .Image("TIM图片20190919172343.jpg")
               .Text($"一位小伙伴悄然离去~{context.ToQq} {isAdminOpt}")
               .Done();

            // todo 填充处理逻辑
            //throw new NotImplementedException();

            // 不要忘记在MahuaModule中注册
        }
    }
}
