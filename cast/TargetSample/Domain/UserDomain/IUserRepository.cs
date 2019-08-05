using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainCore;
using UserDomain.Model;

namespace UserDomain
{
    public interface IUserRepository:IRepository<User>
    {

        Task<User> GetAsync(int id);

    }
}
