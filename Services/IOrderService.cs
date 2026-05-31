using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Services
{
    public interface IOrderService
    {

        Task<OrderResponseDto> PlaceOrderAsync(OrderDto orderDto);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<string> UpdateOrdersStatusAsync(int orderId, string status);
        
    }
}
