using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Model;

namespace UserApplication.Service
{
    public interface IUserService
    {

        Task<User> GetUserAsync(int id);

    }
}
