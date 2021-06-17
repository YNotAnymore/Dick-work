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
    public class SendMsgInfo : MsgInfo
    {
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
