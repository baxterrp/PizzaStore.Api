using PizzaStore.Api.Interfaces;
using PizzaStore.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Api.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<string, Order> _ordersTable;

        public OrderRepository()
        {
            _ordersTable = new Dictionary<string, Order>();
        }

        public async Task<Order> AddOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();

            _ordersTable.Add(order.Id, order); 

            await Task.Delay(3000);

            return order;
        }

        public async Task DeleteOrder(string orderId)
        {
            _ordersTable.Remove(orderId);

            await Task.Delay(3000);
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            await Task.Delay(3000);

            return _ordersTable[orderId];
        }

        public async Task UpdateOrder(Order order)
        {
            _ordersTable[order.Id] = order;

            await Task.Delay(3000);
        }
    }
}
