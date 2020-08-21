using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.DBContexts;
using OrderService.Model;

namespace OrderService.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _dbContext;

        public OrderRepository(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrder(int OrderId)
        {
            var order = _dbContext.Orders.Find(OrderId);
            _dbContext.Orders.Remove(order);
            Save();
        }

        public Order GetOrderById(int OrderId)
        {
            return _dbContext.Orders.Find(OrderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public void InsertOrder(Order order)
        {
            _dbContext.Add(order);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            Save();
        }
    }
}
