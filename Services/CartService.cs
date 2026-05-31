using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;

namespace OnlineShoppingStore.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<CartDto> GetCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cart == null)
                return new CartDto { UserId = userId, Items = new List<CartItemDto>(), TotalAmount = 0 };

            var cartDto = MapToCartDto(cart);
            return cartDto;
        }

        public async Task<CartDto> AddToCartAsync(string userId, AddToCartDto dto)
        {
            var product = await _productRepository.GetProductByIdAsync(dto.ProductId);
            if (product == null)
                throw new Exception($"Product with ID {dto.ProductId} not found.");

            if (product.Stock < dto.Quantity)
                throw new Exception($"Insufficient stock for {product.Name}.");

            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow
                };
                cart = await _cartRepository.CreateCartAsync(cart);
            }

            // Check if item already exists in cart
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
                await _cartRepository.UpdateCartItemAsync(existingItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    UnitPrice = product.Price
                };
                await _cartRepository.AddCartItemAsync(cartItem);
            }

            cart.LastModifiedDate = DateTime.UtcNow;
            return await GetCartAsync(userId);
        }

        public async Task<bool> UpdateCartItemAsync(UpdateCartItemDto dto)
        {
            var cartItem = await _cartRepository.GetCartItemByIdAsync(dto.CartItemId);
            if (cartItem == null) return false;

            if (dto.Quantity <= 0) return false;

            cartItem.Quantity = dto.Quantity;
            return await _cartRepository.UpdateCartItemAsync(cartItem);
        }

        public async Task<bool> RemoveFromCartAsync(int cartItemId)
        {
            return await _cartRepository.RemoveCartItemAsync(cartItemId);
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null) return false;

            return await _cartRepository.ClearCartAsync(cart.CartId);
        }

        private CartDto MapToCartDto(Cart cart)
        {
            var cartItemDtos = cart.Items.Select(item => new CartItemDto
            {
                CartItemId = item.CartItemId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                SubTotal = item.Quantity * item.UnitPrice
            }).ToList();

            var totalAmount = cartItemDtos.Sum(x => x.SubTotal);
            var totalItems = cartItemDtos.Sum(x => x.Quantity);

            return new CartDto
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                Items = cartItemDtos,
                TotalAmount = totalAmount,
                TotalItems = totalItems
            };
        }
    }
}