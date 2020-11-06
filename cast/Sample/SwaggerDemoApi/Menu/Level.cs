using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemoApi.Menu
{
    /// <summary>
    /// 级别
    /// </summary>
    [Description("级别")]
    public enum Level
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Default = 0,
        /// <summary>
        /// 大众
        /// </summary>
        [Description("大众")]
        Normal = 1,
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        Vip = 2,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin = 3

    }
}
