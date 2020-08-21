using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Model;
using OrderService.Repository;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetOrders();
            return new OkObjectResult(orders);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            return new OkObjectResult(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            using (var scope = new TransactionScope())
            {
                _orderRepository.InsertOrder(order);
                scope.Complete();
                return CreatedAtAction(nameof(Get), order);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (order != null)
            {
                using (var scope = new TransactionScope())
                {
                    _orderRepository.UpdateOrder(order);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
            return new OkResult();
        }
    }
}
