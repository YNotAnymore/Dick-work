using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore;
using UserDomain;
using UserDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace UserAppContext
{
    public class UserRepository : IUserRepository
    {

        private UserDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(int id)
        {
            var info = await _context.Users.FirstOrDefaultAsync<User>(u => u.Id == id);
            return info;
        }
    }
}
