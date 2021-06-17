using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Model
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 10:52:49 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class MsgInfo
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
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 传递结果
        /// </summary>
        public object Result { get; set; }
    }

    public enum MsgType : byte
    {
        /// <summary>
        /// 消息推送
        /// </summary>
        Notice = 1,
        /// <summary>
        /// 流推送
        /// </summary>
        StreamNotice = 2,
        /// <summary>
        /// 执行返回
        /// </summary>
        CallBack = 3,
        /// <summary>
        /// 流调用消息
        /// </summary>
        StreamCall = 4,
        /// <summary>
        /// 取消调用
        /// </summary>
        CancelStream = 5,
        /// <summary>
        /// 心跳消息
        /// </summary>
        Heartbeat = 6,
        /// <summary>
        /// 连接关闭
        /// </summary>
        Closed = 7,
    }

}
