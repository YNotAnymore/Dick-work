using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderApplication.Dto;
using OrderApplication.Service;
using OrderDomain.Model;
using Polly;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator,
            ILogger<OrderController> logger, IOrderService orderService, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetListByUser(int userId)
        {
            try
            {
                var list = await _orderService.GetListByUser(userId);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddItem([FromBody] OrderDto dto)
        {
            try
            {
                if (dto == null)
                    return NotFound("参数不能为空！");

                var order = _mapper.Map<Order>(dto);

                var res = await _orderService.CreateItem(order);

                if (!res)
                    return NotFound();

                dto = _mapper.Map<OrderDto>(order);
                var retryPolicy = Policy<Task<string>>.Handle<Exception>().Retry(2, (ex, count) =>
                {
                    _logger.LogDebug($"执行失败! 重试次数:{count}");
                    _logger.LogDebug($"异常来自 {ex}");
                });

                var fallBackPolicy =
                    Policy<Task<string>>
                        .Handle<Exception>()
                        .Fallback(Task<string>.Run(() => "执行失败，返回Fallback"));

                var wrapPolicy = Policy.Wrap(fallBackPolicy, retryPolicy);

                var publishRes = await wrapPolicy.Execute(async () =>
                {
                    await _mediator.Publish(dto);
                    return "success";
                });


                return Ok(new {data = dto, publishRes});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return NotFound(ex);
            }
        }

        [HttpPost]
        [Route("count")]
        public async Task<IActionResult> GetCount()
        {
            var count = await _orderService.GetCount();

            return Ok(count);
        }

        [HttpGet]
        [Route("empty/test")]
        public IActionResult Test(string msg)
        {
            return Ok($"传入msg:{msg}");
        }
    }
}