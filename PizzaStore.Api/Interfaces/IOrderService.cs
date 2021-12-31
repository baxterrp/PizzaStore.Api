using PizzaStore.Api.Models;
using System.Threading.Tasks;

namespace PizzaStore.Api.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task<Order> GetOrderById(string orderId);
        Task DeleteOrder(string orderId);
    }
}
