using OrderDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Service
{
    public interface IOrderService
    {

        Task<IEnumerable<Order>> GetListByUser(int userId);

        Task<bool> CreateItem(Order order);

        Task<int> GetCount();

    }
}
