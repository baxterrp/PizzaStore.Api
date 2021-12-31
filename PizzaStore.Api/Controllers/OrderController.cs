using Microsoft.AspNetCore.Mvc;
using PizzaStore.Api.Interfaces;
using PizzaStore.Api.Models;
using System;
using System.Threading.Tasks;

namespace PizzaStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var addedOrder = await _orderService.AddOrder(order);
            return Ok(addedOrder);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            await _orderService.UpdateOrder(order);
            return Ok();
        }

        [HttpGet("/{orderId}")]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            return Ok(order);
        }

        [HttpDelete("/{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return Ok();
        }
    }
}
