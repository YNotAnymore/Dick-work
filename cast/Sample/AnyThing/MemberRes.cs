using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing
{

    public class MemberRes
    {

        public string Id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadProtrait { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginNumber { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastloginTime { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 剩余U币
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// 电话区号
        /// </summary>
        public string PhoneArea { get; set; }

        /// <summary>
        /// 是否设置过昵称
        /// </summary>
        public bool SetupNickName { get; set; }

        /// <summary>
        /// 注册来源
        /// </summary>
        public int Source { get; set; }
        public string WechatUnionId { get; set; }
        public string WechatOpenId { get; set; }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WechatNickName { get; set; }
        /// <summary>
        /// 团队
        /// </summary>
        public string Team { get; set; }
    }
}
