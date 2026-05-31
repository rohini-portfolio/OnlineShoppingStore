using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.Common;
using OnlineShoppingStore.Data;
using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Services
{
    // Handles order processing and management
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        // Places a new order from cart items and decrements product stock and calculates total amount

        public async Task<OrderResponseDto> PlaceOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                UserId = orderDto.UserId,
                TotalAmount = 0,
                Status = OrderStatus.Pending,
                OrderDate = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            foreach (var item in orderDto.Items)
            {
                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                if (product == null)
                {
                    return new OrderResponseDto
                    {
                        Message = $"Product with ID {item.ProductId} not found.",
                        OrderId = 0
                    };
                }

                if (product.Stock < item.Quantity)
                {
                    return new OrderResponseDto
                    {
                        Message = $"Insufficient stock for {product.Name}.",
                        OrderId = 0
                    };
                }

                product.Stock -= item.Quantity;
                await _productRepository.UpdateProductAsync(product);

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                order.Items.Add(orderItem);
                order.TotalAmount += orderItem.UnitPrice * item.Quantity;
            }

            await _orderRepository.AddOrderAsync(order);

            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                Message = "Order placed successfully.",
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _orderRepository.GetOrdersByUserAsync(userId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<string> UpdateOrdersStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return $"Order with ID {orderId} not found.";
            }
            order.Status = status;
            await _orderRepository.UpdateOrderAsync(order);
            return "Order status updated successfully.";
        }
    }
}