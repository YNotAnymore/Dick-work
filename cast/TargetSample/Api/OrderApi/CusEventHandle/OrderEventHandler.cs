using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderApplication.Dto;

namespace OrderApi.CusEventHandle
{
    public class OrderEventHandler : INotificationHandler<OrderDto>
    {
        private ILogger<OrderEventHandler> _logger;

        public OrderEventHandler(ILogger<OrderEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(OrderDto notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"收到订单创建通知，param:{JsonConvert.SerializeObject(notification)}");

            _logger.LogDebug("查找参与项目");

            _logger.LogDebug("处理佣金部分....");

            _logger.LogDebug("处理返利部分...");

            return Task.CompletedTask;
        }
    }
}