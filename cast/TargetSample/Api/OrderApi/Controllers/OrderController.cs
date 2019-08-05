using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderApplication.Service;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService { get; set; }

        private readonly IMediator _mediator;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OrderController> _logger;
        private readonly IConfiguration Configuration;

        public OrderController(IMediator mediator, IHttpClientFactory httpClientFactory, ILogger<OrderController> logger, IConfiguration configuration, IOrderService orderService)
        {
            _mediator = mediator;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            Configuration = configuration;
            _orderService = orderService;
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
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}