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
using UserApplication.Dto;
using UserApplication.Service;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration Configuration;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="httpClientFactory"></param>
        /// <param name="userService"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public UserController(IMediator mediator, IHttpClientFactory httpClientFactory,
            IUserService userService, ILogger<UserController> logger, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger;
            Configuration = configuration;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {

            try
            {
                var user = await _userService.GetUserAsync(id);

                return Ok(user);
            }
            catch
            {
                return NotFound();
            }

        }

    }
}