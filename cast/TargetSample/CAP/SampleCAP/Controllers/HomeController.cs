using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleCAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ICapPublisher _capPublisher;
        private ILogger<HomeController> _logger;

        public HomeController(ICapPublisher capPublisher, ILogger<HomeController> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        [HttpGet, Route("send")]
        public async Task<IActionResult> Send()
        {
            var newGuid = Guid.NewGuid();

            await _capPublisher.PublishAsync("sample.service.show.msg", newGuid);

            return Ok(newGuid);
        }


        [HttpGet, Route("send/user")]
        public async Task<IActionResult> SendToUser()
        {
            var newGuid = Guid.NewGuid();

            await _capPublisher.PublishAsync("user.service.show.msg", newGuid);

            return Ok(newGuid);
        }

        [NonAction, CapSubscribe("sample.service.show.msg")]
        public void ReceiverMsg(string msg)
        {
            _logger.LogInformation($"接收到msg:{msg}");
        }
    }
}