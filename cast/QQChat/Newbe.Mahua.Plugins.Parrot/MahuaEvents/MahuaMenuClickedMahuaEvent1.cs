using Newbe.Mahua.MahuaEvents;
using System;

namespace Newbe.Mahua.Plugins.Parrot.MahuaEvents
{
    /// <summary>
    /// 菜单点击事件
    /// </summary>
    public class MahuaMenuClickedMahuaEvent1
        : IMahuaMenuClickedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public MahuaMenuClickedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessManhuaMenuClicked(MahuaMenuClickedContext context)
        {

            // todo 填充处理逻辑
            //throw new NotImplementedException();

            // 不要忘记在MahuaModule中注册
        }
    }
}
