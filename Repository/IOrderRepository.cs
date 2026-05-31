using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Dtos;

namespace OnlineShoppingStore.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}
