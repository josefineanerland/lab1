using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Model;

namespace OrderService.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int OrderId);
        void InsertOrder(Order Order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(Order order);
        void Save();
    }
}
