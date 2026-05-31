using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using OnlineShoppingStore.Common;

namespace OnlineShoppingStore.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public PaymentService(IPaymentRepository paymentRepository, IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        public async Task<PaymentResponseDto> ProcessPaymentAsync(string userId, PaymentDto dto)
        {
            // Validate order exists and belongs to user
            var order = await _orderRepository.GetOrderByIdAsync(dto.OrderId);
            if (order == null || order.UserId != userId)
                throw new Exception("Order not found or unauthorized.");

            // Mock Payment Processing
            bool paymentSuccess = MockPaymentGateway(dto.PaymentMethod);

            var payment = new Payment
            {
                OrderId = dto.OrderId,
                UserId = userId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                Status = paymentSuccess ? PaymentStatus.Success : PaymentStatus.Failed,
                PaymentDate = DateTime.UtcNow,
                TransactionId = GenerateTransactionId(),
                Description = dto.Description
            };

            var createdPayment = await _paymentRepository.CreatePaymentAsync(payment);

            // If payment successful, update order status
            if (paymentSuccess)
            {
                order.Status = OrderStatus.Completed;
                await _orderRepository.UpdateOrderAsync(order);

                // Clear user's cart
                await _cartRepository.ClearCartAsync(order.OrderId); // This might need adjustment
            }

            return MapToPaymentResponseDto(createdPayment);
        }

        public async Task<PaymentResponseDto> GetPaymentAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(paymentId);
            if (payment == null)
                throw new Exception("Payment not found.");

            return MapToPaymentResponseDto(payment);
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetUserPaymentsAsync(string userId)
        {
            var payments = await _paymentRepository.GetPaymentsByUserIdAsync(userId);
            return payments.Select(p => MapToPaymentResponseDto(p)).ToList();
        }

        // Mock Payment Gateway - 80% success rate
        private bool MockPaymentGateway(string paymentMethod)
        {
            Random random = new Random();
            int successChance = random.Next(1, 101);
            return successChance <= 80; // 80% success rate
        }

        // Generate mock transaction ID
        private string GenerateTransactionId()
        {
            return "TXN" + DateTime.UtcNow.Ticks.ToString().Substring(0, 12);
        }

        private PaymentResponseDto MapToPaymentResponseDto(Payment payment)
        {
            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                Amount = payment.Amount,
                Status = payment.Status,
                TransactionId = payment.TransactionId,
                PaymentDate = payment.PaymentDate
            };
        }
    }
}