using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Model
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 12:15:31 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class NewMsgNotice
    {
        /// <summary>
        /// 会话id
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 是否自己发送
        /// </summary>
        public bool IsOwnerSend { get; set; }
    }
}
