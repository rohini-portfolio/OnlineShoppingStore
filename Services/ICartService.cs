using OnlineShoppingStore.Dtos;

namespace OnlineShoppingStore.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(string userId);
        Task<CartDto> AddToCartAsync(string userId, AddToCartDto dto);
        Task<bool> UpdateCartItemAsync(UpdateCartItemDto dto);
        Task<bool> RemoveFromCartAsync(int cartItemId);
        Task<bool> ClearCartAsync(string userId);
    }
}