using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using OrderDomain;
using OrderDomain.Model;

namespace OrderAppContext
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<IEnumerable<Order>> GetListByUserAsync(int userId)
        {
            var list = await _dbContext.Orders.Where(u => u.UserId == userId).ToListAsync();

            return list;
        }

        public async Task<bool> CreateItem(Order order)
        {
            order.CreateTime = DateTime.Now;
            order.Id = 0;

            await _dbContext.Orders.AddAsync(order);

            return _dbContext.Commit();
        }

        public Task<int> GetCount()
        {
            return _dbContext.Orders.CountAsync();
        }
    }
}