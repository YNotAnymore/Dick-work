using DomainCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using MediatR;
using UserDomain;
using Microsoft.EntityFrameworkCore;
using OrderAppContext.EntityConfiguration;
using OrderDomain;
using OrderDomain.Model;

namespace OrderAppContext
{
    public class OrderDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;
        private IOrderRepository _orderRepository;
        private ILogger<OrderDbContext> _logger;

        public OrderDbContext()
        {
        }

        protected OrderDbContext(IMediator mediator,ILogger<OrderDbContext> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public OrderDbContext(DbContextOptions options, IMediator mediator, OrderRepository orderRepository,
            ILogger<OrderDbContext> logger) : base(options)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
            _logger = logger;
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

        public string ConnectionString { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }

        public bool Commit()
        {
            return base.SaveChanges() > 0;
        }

        public DbSet<Order> Orders { get; set; }
    }
}