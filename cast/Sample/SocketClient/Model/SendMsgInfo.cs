using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Model
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 11:28:15 AM
    /// @source : 
    /// @des : 发送参数
    /// </summary>
    public class SendMsgInfo
    {

        /// <summary>
        /// 参数
        /// </summary>
        public object[] Arguments { get; set; }
        /// <summary>
        /// 消息的唯一id
        /// </summary>
        public string InvocationId { get; set; }
        /// <summary>
        /// 调用目标
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType Type { get; set; }
        /// <summary>
        /// 异步流id
        /// </summary>
        public string[] StreamIds { get; set; }
        /// <summary>
        /// 构建一个invoke消息
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="invocationId"></param>
        /// <param name="target"></param>
        public SendMsgInfo(object[] arguments, string invocationId, string target)
        {
            Arguments = arguments;
            InvocationId = invocationId;
            Target = target;
            Type = MsgType.Notice;
            StreamIds = Array.Empty<string>();
        }
    }
}
