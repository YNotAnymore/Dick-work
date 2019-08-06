using DomainCore;
using OrderDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomain
{
    public interface IOrderRepository:IRepository<Order>
    {

        Task<IEnumerable<Order>> GetListByUserAsync(int userId);
        Task<bool> CreateItem(Order order);

        Task<int> GetCount();
    }
}
