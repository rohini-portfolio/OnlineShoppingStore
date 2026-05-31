using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.Services;
using OnlineShoppingStore.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingStore.Data;
using OnlineShoppingStore.Models;
using System.Security.Claims;
using OnlineShoppingStore.Common;

namespace OnlineShoppingStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensure that only authenticated users can access these endpoints
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        //Customer : Place a new Order
        //Customer : Place a new Order
        [HttpPost]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            //Attach the user ID from the JWT token to the order DTO
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            orderDto.UserId = userId;

            var result = await _orderService.PlaceOrderAsync(orderDto);

            if (result.OrderId == 0)
                return BadRequest(new { Message = result.Message });

            return Ok(result);
        }

        //Customer : View their orders
        [HttpPost("my")]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        //Admin : View all orders
        [HttpGet("all")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        //Admin : Update order status
        [HttpPut("{orderId}/status")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
        {
            var result = await _orderService.UpdateOrdersStatusAsync(orderId, status);
            if (result == null)
                return NotFound(new { Message = $"Order {orderId} not found." }); 
            return Ok(new { Message = "Order status updated successfully." });
        }
    }
}
