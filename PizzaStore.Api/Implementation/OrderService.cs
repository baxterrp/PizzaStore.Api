using Microsoft.Extensions.Caching.Memory;
using PizzaStore.Api.Interfaces;
using PizzaStore.Api.Models;
using System;
using System.Threading.Tasks;

namespace PizzaStore.Api.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMemoryCache _memoryCache;

        public OrderService(IOrderRepository orderRepository, IMemoryCache memoryCache)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<Order> AddOrder(Order order)
        {
            var addedOrder = await _orderRepository.AddOrder(order);

            //var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
            //_memoryCache.Set(addedOrder.Id, addedOrder, options);

            return addedOrder;
        }

        public async Task DeleteOrder(string orderId)
        {
            await _orderRepository.DeleteOrder(orderId);

            //_memoryCache.Remove(orderId);
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            //if (_memoryCache.TryGetValue(orderId, out Order order))
            //{
            //    return order;
            //}

            return await _orderRepository.GetOrderById(orderId);
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderRepository.UpdateOrder(order);

            //_memoryCache.Remove(order.Id);
            //_memoryCache.Set(order.Id, order);
        }
    }
}
