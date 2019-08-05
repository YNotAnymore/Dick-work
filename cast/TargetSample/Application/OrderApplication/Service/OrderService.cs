using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderDomain;
using OrderDomain.Model;

namespace OrderApplication.Service
{
    public class OrderService:IOrderService
    {

        private IOrderRepository _orderRepository;
        private IMediator mediator;
        private ILogger<OrderService> _logger;
        private IHttpClientFactory _httpClientFactory;

        public OrderService(IOrderRepository orderRepository, IMediator mediator, ILogger<OrderService> logger, IHttpClientFactory httpClientFactory)
        {
            _orderRepository = orderRepository;
            this.mediator = mediator;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public OrderService(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            this.mediator = mediator;
        }

        public Task<IEnumerable<Order>> GetListByUser(int userId)
        {
            return _orderRepository.GetListByUserAsync(userId);
        }
    }
}
