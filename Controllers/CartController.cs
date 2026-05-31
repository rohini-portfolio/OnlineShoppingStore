using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.Common;
using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Services;
using System.Security.Claims;

namespace OnlineShoppingStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.Customer)]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = await _cartService.GetCartAsync(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = await _cartService.AddToCartAsync(userId, dto);
                return Ok(new { Message = "Item added to cart successfully", Cart = cart });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto dto)
        {
            try
            {
                var success = await _cartService.UpdateCartItemAsync(dto);
                if (!success)
                    return NotFound(new { Message = "Cart item not found" });

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = await _cartService.GetCartAsync(userId);
                return Ok(new { Message = "Cart item updated successfully", Cart = cart });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            try
            {
                var success = await _cartService.RemoveFromCartAsync(cartItemId);
                if (!success)
                    return NotFound(new { Message = "Cart item not found" });

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = await _cartService.GetCartAsync(userId);
                return Ok(new { Message = "Item removed from cart successfully", Cart = cart });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var success = await _cartService.ClearCartAsync(userId);
                if (!success)
                    return NotFound(new { Message = "Cart not found" });

                return Ok(new { Message = "Cart cleared successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}