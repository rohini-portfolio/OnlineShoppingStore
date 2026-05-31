using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(string userId, PaymentDto dto);
        Task<PaymentResponseDto> GetPaymentAsync(int paymentId);
        Task<IEnumerable<PaymentResponseDto>> GetUserPaymentsAsync(string userId);
    }
}