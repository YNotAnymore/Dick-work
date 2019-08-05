using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserDomain;
using UserDomain.Model;

namespace UserApplication.Service
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;
        private IMediator mediator;
        private ILogger<UserService> _logger;
        private IHttpClientFactory _httpClientFactory;

        public UserService(IUserRepository userRepository, IMediator mediator,ILogger<UserService> logger,
            IHttpClientFactory httpClientFactory)
        {
            _userRepository = userRepository;
            this.mediator = mediator;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public UserService(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            this.mediator = mediator;
        }

        public Task<User> GetUserAsync(int id)
        {
            return _userRepository.GetAsync(id);
        }
    }
}
