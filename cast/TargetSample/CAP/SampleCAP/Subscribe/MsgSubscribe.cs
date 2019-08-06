using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;

namespace SampleCAP.Subscribe
{
    public interface IMsgSubscribe
    {
        void ReceiverMsg(string msg);
    }

    public class MsgSubscribe : IMsgSubscribe, ICapSubscribe
    {
        private ILogger<MsgSubscribe> _logger;

        public MsgSubscribe(ILogger<MsgSubscribe> logger)
        {
            _logger = logger;
        }

        public MsgSubscribe()
        {
        }

        [CapSubscribe("sample.service.show.msg")]
        public void ReceiverMsg(string msg)
        {
            _logger.LogInformation($"MsgSubscribe 接收到msg:{msg}");
        }
    }
}