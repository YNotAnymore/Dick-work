using DomainCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using UserDomain;
using UserDomain.Model;
using UserAppContext.EntityConfiguration;

namespace UserAppContext
{
    public class UserDbContext : DbContext, IUnitOfWork
    {

        public DbSet<User> Users { get; set; }

        public UserDbContext()
        {
        }

        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;
        private IUserRepository _userRepository;
        private ILogger<UserDbContext> _logger;

        public UserDbContext(DbContextOptions<UserDbContext> options, IMediator mediator, ILogger<UserDbContext> logger) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger;
        }

        // 此处不能使用 IUserRepository 否则注入时会出现循环依赖：
        // UserApplication.Service.IUserService(UserApplication.Service.UserService) -> 
        // UserDomain.IUserRepository(UserAppContext. userrepository) -> 
        // UserAppContext.UserDbContext - > 
        // UserDomain.IUserRepository


        public UserDbContext(DbContextOptions<UserDbContext> options, IMediator mediator, UserRepository userRepository, ILogger<UserDbContext> logger) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userRepository = userRepository;
            _logger = logger;
        }

        public bool Commit()
        {
            return base.SaveChanges() > 0;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Data Source=192.168.3.79;Initial Catalog=langhuaNew;User ID=sa;Password=langhua*8");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public static string ConnectionString { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

    }
}
